namespace OrisonCollegePortal.Shared.Entities.PaymentLink
{
    public class Models
    {
        public Models()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public class OrderRequest
        {
            public string? SchoolCode { get; set; }
            public string? StudentID { get; set; }
            public string? OrderDate { get; set; }
            public Parent? Pt { get; set; }
            public Student? St { get; set; }
            public decimal Amount { get; set; }
            public string? Landing { get; set; }
            public string? InvoiceNumber { get; set; }
            public string? RequestStr { get; set; }
            public string? SessionID { get; set; }
            public string? RespSession { get; set; }
            public string? ConfirmURL { get; set; }
            public string? Purpose { get; set; }
            public string? Type { get; set; }

        }

        public class Parent
        {
            public string? Email { get; set; }
            public string? PFullName { get; set; }
            public string? PFirstName { get; set; }
            public string? PLastName { get; set; }
            public string? Phone { get; set; }
            public string? DOB { get; set; }

        }

        public class Student
        {
            public string? SFullName { get; set; }
            public string? SFirstName { get; set; }
            public string? SLastName { get; set; }
            public string? CurrentClass { get; set; }
            public string? JoiningGrade { get; set; }
            public string? DateOfJoin { get; set; }
            public string? AdmissionDate { get; set; }
            public string? Gender { get; set; }
            public string? RegisterNo { get; set; }
            public string? Nationality { get; set; }

        }


        public class OrderResponse
        {
            public int RequestID { get; set; }
            public string? SessionID { get; set; }
            public string? RespStr { get; set; }
            public string? MDate { get; set; }
        }

        public string ConfirmationURL()
        {
            string url = "http://localhost:51313/apihandler.aspx/";
            return url;
        }
    }
}
