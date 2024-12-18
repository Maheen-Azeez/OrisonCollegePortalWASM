namespace OrisonCollegePortal.Client.Services
{
    public class AccountService
    {
        public string PasswordDecode(string Pwd)
        {
            char[] PwdChar = Pwd.ToCharArray();
            string deCodedPwd = "";
            foreach (char c in PwdChar)
            {
                deCodedPwd = deCodedPwd + (char)(Convert.ToInt32(c) - 10);
            }
            return deCodedPwd;
        }
        public string PasswordEncode(string Pwd)
        {
            char[] PwdChar = Pwd.ToCharArray();
            string EnCodedPwd = "";
            foreach (char c in PwdChar)
            {
                EnCodedPwd = EnCodedPwd + (char)(Convert.ToInt32(c) + 10);
            }
            return EnCodedPwd;

        }
    }
}
