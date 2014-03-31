using DevExpress.Web.ASPxGridView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tempeDB
{
    public partial class home : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            if (queryTextBox.Value != null)
            {
                string queryFull = queryTextBox.Value.ToString();
                int positionWhen = queryFull.IndexOf("WHEN");
                string relational = String.Empty;
                string temporal = String.Empty;
                string tempe = " AND";

                // detecting ID parameter in SELECT clause
                int startPosition = queryFull.IndexOf("SELECT") + 7;
                int endPosition = queryFull.IndexOf("FROM") - 2;
                string selectParam = queryFull.Substring(startPosition, endPosition - startPosition + 1);
                Debug.WriteLine(selectParam);
                if (selectParam.IndexOf("ID") < 0)
                {
                    if (selectParam.IndexOf("*") < 0)
                    {
                        queryFull = queryFull.Insert(endPosition + 1, ", TS, TE");
                        queryFull = queryFull.Insert(startPosition, "ID, ");
                    }
                }
                Debug.WriteLine(queryFull);

                if (positionWhen > 0) // temporal query processing
                {
                    relational = queryFull.Substring(0, positionWhen - 1);
                    temporal = queryFull.Substring(positionWhen);

                    /*----------core processing--------->*/
                    int timePosition = temporal.IndexOf("time");
                    string operatorSign = temporal.Substring(timePosition + 5, 2);
                    string period = temporal.Substring(timePosition + 8);
                    int commaPosition = period.IndexOf(',');
                    char periodStart = period[0]; // ( or [
                    char periodEnd = period[period.Length - 1]; // ) or ]
                    string startString = period.Substring(1, commaPosition - 1);
                    int startValue = Convert.ToInt32(startString);
                    string endString = period.Substring(commaPosition + 1);
                    endString = endString.Remove(endString.Length - 1);
                    int endValue = Convert.ToInt32(endString);

                    Debug.WriteLine(timePosition);
                    Debug.WriteLine(operatorSign);
                    Debug.WriteLine(period);
                    Debug.WriteLine(periodStart);
                    Debug.WriteLine(periodEnd);
                    Debug.WriteLine(startString);
                    Debug.WriteLine(endString);

                    switch (operatorSign)
                    {
                        case "==": // equals
                            if (periodStart == '(')
                                tempe = tempe + " (TS = " + (startValue + 1);
                            else
                                tempe = tempe + " (TS = " + startValue;
                            if (periodEnd == ')')
                                tempe = tempe + " AND TE = " + (endValue - 1) + ")";
                            else
                                tempe = tempe + " AND TE = " + endValue + ")";
                            break;
                        case "!=": // not equals
                            if (periodStart == '(')
                                tempe = tempe + " NOT (TS = " + (startValue + 1);
                            else
                                tempe = tempe + " NOT (TS = " + startValue;
                            if (periodEnd == ')')
                                tempe = tempe + " AND TE = " + (endValue - 1) + ")";
                            else
                                tempe = tempe + " AND TE = " + endValue + ")";
                            break;
                        case "--": // minus
                            break;
                        case "++": // union
                            break;
                        case "@>": // contains
                           if (periodStart == '(')
                                tempe = tempe + " (TS > " + startString;
                            else
                                tempe = tempe + " (TS >= " + startString;
                            if (periodEnd == ')')
                                tempe = tempe + " AND TE < " + endString + ")";
                            else
                                tempe = tempe + " AND TE <= " + endString + ")";
                            break;
                        case "<@": // contained_by
                            break;
                        case "&&": // overlaps
                            if (periodStart == '(')
                                tempe = tempe + " ((TS > " + startString + ") AND (TS < " + endString + ") OR ";
                            else
                                tempe = tempe + " ((TS >= " + startString + ") AND (TS <= " + endString + ") OR ";
                            if (periodEnd == ')')
                                tempe = tempe + "((TE > " + startString + ") AND (TE < " + endString + "))";
                            else
                                tempe = tempe + "((TE >= " + startString + ") AND (TE <= " + endString + "))";
                            break;
                        case "<<": // before
                            if (periodStart == '(')
                                tempe = tempe + " (TE <= " + startString + ")";
                            else
                                tempe = tempe + " (TE < " + startString + ")";
                            break;
                        case ">>": // after
                            if (periodEnd == ')')
                                tempe = tempe + " (TS >= " + endString + ")";
                            else
                                tempe = tempe + " (TS > " + endString + ")";
                            break;
                        case "&<": // overleft
                            if (periodStart == '(')
                                tempe = tempe + " (TS <= " + (startValue + 1) + ")";
                            else
                                tempe = tempe + " (TS <= " + startValue + ")";
                            break;
                        case "&>": // overright
                            if (periodEnd == ')')
                                tempe = tempe + " (TE >= " + (endValue - 1) + ")";
                            else
                                tempe = tempe + " (TE >= " + endValue + ")";
                            break;
                    }

                    /*---------------------------------------*/
                    Debug.WriteLine(tempe);
                    relational = relational + tempe;
                    Debug.WriteLine(relational);
                }
                else // relational query processing
                {
                    relational = queryFull;
                    Debug.WriteLine(relational);
                }
                               
                /*--------------result--------------------*/
                ASPxGridView result = new ASPxGridView();
                result.ID = "result";
                result.KeyFieldName = "ID";  
                panel1.Controls.Add(result);
                result.SettingsBehavior.AllowFocusedRow = true;
                result.SettingsPager.Mode = GridViewPagerMode.EndlessPaging;
                result.SettingsPager.PageSize = Int32.MaxValue;

                string conn = "Data Source=(local);Initial Catalog=tempeDB;Integrated Security=True";
                result.DataSource = new SqlDataSource(conn, relational);
                result.DataBind();
                
            }
        }
    }
}