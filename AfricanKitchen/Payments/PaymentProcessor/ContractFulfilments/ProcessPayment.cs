using PaymentProcessor.Contracts;

namespace PaymentProcessor.ContractFulfilments
{
    internal class ProcessPayment : IProcessPayment
    {
        public bool PaymentProcessor()
        {
            //Implement custom logic and get card details
            return true;
        }
    }
}
