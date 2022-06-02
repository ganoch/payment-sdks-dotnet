
namespace GolomtEcommerse
{

    public interface Request
    {
        void computeHash(string secret);
    }

    public class CreateInvoiceRequest : Request
    {
        public string amount { get; set; }
        public string transactionId { get; set; }
        // POST GET MOBILE
        public string returnType { get; set; }
        public string callback { get; set; }
        public bool getToken { get; set; }
        public string checksum { get; set; }

        public CreateInvoiceRequest(float amount, string transactionId, string returnType, string callback, bool getToken)
        {
            this.amount = amount.ToString("n2");
            this.transactionId = transactionId;
            this.callback = callback;
            this.getToken = getToken;
            this.returnType = returnType;
            this.checksum = "";
        }

        public void computeHash(string secret)
        {
            string data = transactionId + amount + returnType + callback;
            checksum = Utils.GetHMAC(secret, data);
        }
    }

    public class InquiryRequest : Request
    {
        public string transactionId { get; set; }
        public string checksum { get; set; }

        public InquiryRequest(string transactionId)
        {
            this.transactionId = transactionId;
            this.checksum = "";
        }

        public void computeHash(string secret)
        {
            string data = transactionId + transactionId;
            checksum = Utils.GetHMAC(secret, data);
        }
    }

    public class PayByTokenRequest: Request
    {
        public string amount { get; set; }
        public string invoice { get; set; }
        public string transactionId { get; set; }
        public string token { get; set; }
        public string checksum { get; set; }
        public string lang { get; set; }

        public PayByTokenRequest(string transactionId, string token, string invoice, float amount, string lang)
        {
            this.transactionId = transactionId;
            this.token = token;
            this.invoice = invoice;
            this.amount = amount.ToString("n2");
            this.lang = lang;
            this.checksum = "";
        }


        public void computeHash(string secret)
        {
            string data = amount + transactionId + token;
            checksum = Utils.GetHMAC(secret, data);
        }
    }

    public class PayByTokenResponse {
        public string amount { get; set; } = string.Empty;
        
        public string errorDesc { get; set; } = string.Empty;
        public string errorCode { get; set; } = string.Empty;
        public string transactionId { get; set; } = string.Empty;
        public string checksum { get; set; } = string.Empty;
        public string cardNumber { get; set; } = string.Empty;
    }

    public class InquiryResponse
    {
        public string amount { get; set; } = string.Empty;
        public string bank { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string errorDesc { get; set; } = string.Empty;
        public string errorCode { get; set; } = string.Empty;
        public string cardHolder   { get; set; } = string.Empty;
        public string cardNumber   { get; set; } = string.Empty;
        public string transactionId { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
    }

    public class CreateInvoiceResponse
    {
        public string invoice { get; set; } = string.Empty;
        public string checksum { get; set; } = string.Empty;
        public string transactionId { get; set; } = string.Empty;
        public string timestamp { get; set; } = string.Empty;
        public int status { get; set; }
        public string error { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public string path { get; set; } = string.Empty;

    }
}