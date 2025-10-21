namespace Shop
{
    public class TransactionPreviewButton
    {
        private readonly TransactionPreview _transactionPreview;
        private readonly Transaction _transaction;

        public TransactionPreviewButton(TransactionPreview transactionPreview, Transaction transaction)
        {
            _transactionPreview = transactionPreview;
            _transaction = transaction;
        }
        
        public void Click()
        {
            _transactionPreview.Show(_transaction);
        }
    }
}