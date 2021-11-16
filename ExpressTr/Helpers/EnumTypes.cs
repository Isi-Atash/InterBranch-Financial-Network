namespace ExpressTr.Helpers
{
    public class EnumTypes
    {
        public enum ModuleIds 
        {
            Express = 943
        }

        public enum DocumentTypes
        {
            Transfers = 1432
        }

        public enum ConfirmMode
        {
            Sign,
            Details
        }

        public enum PageMode
        {
            Add,
            View,
            Edit,
            Sign
        }

        public enum CipherMode
        {
            Refund,
            Cipher
        }

        public enum ExpressType
        {
            In,
            Out,
            Returned
        }
    }
}
