using System.Data;

namespace OrisonCollegePortal.Shared.Entities.PaymentLink
{
    public class Utility //: System.Web.UI.Page
    {
        public Utility()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string MCreateSession(Models.OrderRequest objrequest, DataTable msdt)
        {

            string jsonContent = "";
            int i;


            jsonContent = "{\"merchant\":{\"confirmationURL\": \"" + objrequest.ConfirmURL + "\"},\"parent\": {\"emailId\": \"" + objrequest.Pt!.Email + "\",\"phone\": \"" + objrequest.Pt.Phone + "\",\"fullName\": \"" + objrequest.Pt.PFullName + "\"}," +
                "\"student\": {\"fullName\": \"" + objrequest.St!.SFullName + "\",\"currentClass\": \"" + objrequest.St.CurrentClass + "\",\"registerNo\": \"" + objrequest.St.RegisterNo + "\"}," +
                "\"s2s\": {\"amount\": " + objrequest.Amount + "},\"landing\": {\"to\": \"" + objrequest.Landing + "\"}," +
                "\"studentAmountMappingList \":[";

            for (i = 0; i < msdt.Rows.Count; i++)
            {
                if (i == msdt.Rows.Count - 1)
                {
                    jsonContent = jsonContent + "{\"studentRegisterNo\": \"" + msdt.Rows[i]["RefNo"].ToString() + "\",\"amount\": \"" + msdt.Rows[i]["Amount"].ToString() + "\"}";
                    break;
                }
                jsonContent = jsonContent + "{\"studentRegisterNo\": \"" + msdt.Rows[i]["RefNo"].ToString() + "\",\"amount\": \"" + msdt.Rows[i]["Amount"].ToString() + "\"},";

            }

            jsonContent = jsonContent + "]}";

            return jsonContent;
        }

        public string CreateSession(Models.OrderRequest objrequest)
        {
            //Models.OrderRequest objrequest = new Models.OrderRequest();
            string jsonContent = "";

            // jsonContent = "{\"landing\": {\"to\": \"" + objrequest.Landing + "\",\"purpose\": \"" + objrequest.Purpose + "\",\"type\": \"" + objrequest.Type + "\"},\"s2s\": {\"amount\": " + objrequest.Amount + "},\"parent\": {\"fullName\": \"" + objrequest.Pt.PFullName+ "\",\"emailId\": \"" + objrequest.Pt.Email + "\",\"phone\": \"" + objrequest.Pt.Phone + "\"},\"student\": {\"fullName\": \"" + objrequest.St.SFullName + "\",\"currentClass\": \"" + objrequest.St.CurrentClass + "\",\"joiningGrade\": \"" + objrequest.St.JoiningGrade + "\",\"gender\": \"" + objrequest.St.Gender + "\",\"registerNo\": \"" + objrequest.St.RegisterNo + "\"},\"merchant\": {\"confirmationURL\": \"https://orisonpay.com/Zendapay/apihandler.aspx\"}}"; 


            // objrequest.Pt.Phone = "+971545125456";

            jsonContent = "{\"landing\": {\"to\": \"" + objrequest.Landing + "\"},\"s2s\": {\"amount\": " + objrequest.Amount + "},\"parent\": {\"fullName\": \"" + objrequest.Pt!.PFullName + "\",\"emailId\": \"" + objrequest.Pt.Email + "\",\"phone\": \"" + objrequest.Pt.Phone + "\"},\"student\": {\"fullName\": \"" + objrequest.St!.SFullName + "\",\"currentClass\": \"" + objrequest.St.CurrentClass + "\",\"joiningGrade\": \"" + objrequest.St.JoiningGrade + "\",\"gender\": \"" + objrequest.St.Gender + "\",\"registerNo\": \"" + objrequest.St.RegisterNo + "\"},\"type\": \"" + objrequest.Type + "\",\"purpose\": \"" + objrequest.Purpose + "\",\"merchant\": {\"confirmationURL\": \"" + objrequest.ConfirmURL + "\"}}";

            //jsonContent = "{\"landing\": {\"to\": \"" + objrequest.Landing + "\"},\"s2s\": {\"amount\": " + objrequest.Amount + "},\"parent\": {\"fullName\": \"" + objrequest.Pt.PFullName+ "\",\"emailId\": \"" + objrequest.Pt.Email + "\",\"phone\": \"" + objrequest.Pt.Phone + "\"},\"student\": {\"fullName\": \"" + objrequest.St.SFullName + "\",\"currentClass\": \"" + objrequest.St.CurrentClass + "\",\"joiningGrade\": \"" + objrequest.St.JoiningGrade + "\",\"gender\": \"" + objrequest.St.Gender + "\",\"registerNo\": \"" + objrequest.St.RegisterNo + "\"},\"type\": \"" + objrequest.Type + "\",\"purpose\": \"" + objrequest.Purpose + "\",\"merchant\": {\"confirmationURL\": \"https://portal.icschool-uae.com:8001/Zendapay/apihandler.aspx\"}}";


            return jsonContent;
        }
    }
}
