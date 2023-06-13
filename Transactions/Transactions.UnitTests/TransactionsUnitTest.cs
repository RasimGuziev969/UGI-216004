using Bank;
using Transactions;

namespace TransactionsUnitTestProject
{
    [TestFixture]
    public class TransactionsUnitTest
    {
        [Test]
        public void DepositTransactionTest()
        {
            var ui = new FakeBankUI { DepositAmount = 40 };
            var account = new Account();
            var transaction = new DepositTransaction(ui, account);

            Assert.That(account.Funds, Is.EqualTo(0).Within(1e-3));

            transaction.Execute();

            Assert.That(account.Funds, Is.EqualTo(40).Within(1e-3));
            
            ui.DepositAmount = 50;
            transaction.Execute();

            Assert.That(account.Funds, Is.EqualTo(90).Within(1e-3));
        }

        [Test]
        public void WithdrawalTransactionTest()
        {
            var ui = new FakeBankUI { WithdrawalAmount = 50 };
            var account = new Account { Funds = 80 };
            var transaction = new WithdrawalTransaction(ui, account);

            Assert.That(account.Funds, Is.EqualTo(80).Within(1e-3));
            Assert.IsFalse(ui.IsInsuffisientFunds);

            transaction.Execute();

            Assert.That(account.Funds, Is.EqualTo(30).Within(1e-3));
            Assert.IsFalse(ui.IsInsuffisientFunds);

            transaction.Execute();

            Assert.That(account.Funds, Is.EqualTo(30).Within(1e-3));
            Assert.IsTrue(ui.IsInsuffisientFunds);
        }

        [Test]
        public void TransferTransactionTest()
        {
            var ui = new FakeBankUI { TransferAmount = 50 };
            var source = new Account { Funds = 80 };
            var target = new Account();
            var transaction = new TransferTransaction(ui, source, target);

            Assert.That(source.Funds, Is.EqualTo(80).Within(1e-3));
            Assert.That(target.Funds, Is.EqualTo(0).Within(1e-3));
            Assert.IsFalse(ui.IsInsuffisientFunds);

            transaction.Execute();

            Assert.That(source.Funds, Is.EqualTo(30).Within(1e-3));
            Assert.That(target.Funds, Is.EqualTo(50).Within(1e-3));
            Assert.IsFalse(ui.IsInsuffisientFunds);

            transaction.Execute();

            Assert.That(source.Funds, Is.EqualTo(30).Within(1e-3));
            Assert.That(target.Funds, Is.EqualTo(50).Within(1e-3));
            Assert.IsTrue(ui.IsInsuffisientFunds);
        }
    }

}
