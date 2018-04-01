using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Repository;

namespace RavenDbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = DocumentStoreHandler.Store.OpenSession())
            {
                IFinancialAdvisorRepository financialAdvisorRepository = new FinancialAdvisorRepository(session);

                var advisor = new FinancialAdvisor
                {
                    PersonId = 3,
                    PersonName = "Mr FinancialAdvisor3",
                    SECRegistrationNumber = "FN1ABC125"
                };                

                var client = new Client
                {
                    PersonId = 2,
                    PersonName = "Mr Client2",
                    ClientRegistrationNumber = "CL2ABC123"
                };

                var account = new Account
                {
                     AccountNumber = "FN3CL3A124",
                     AccountFund = 100000,
                     FinancialAdvisor = advisor,
                     Client = client
                };                               
                                
                session.Store(account);
                string accountId = session.Advanced.GetDocumentId(account);
                session.SaveChanges();

                List<FinancialAdvisor> advisors = session.Query<FinancialAdvisor>().ToList();                
            }
        }
    }
}

/*
IFinancialAdvisorRepository financialAdvisorRepository = new FinancialAdvisorRepository(session);
                                
                var advisor = new FinancialAdvisor
                {
                    PersonId = 3,
                    PersonName = "Mr FinancialAdvisor3",
                    SECRegistrationNumber = "FN1ABC125"
                };
                financialAdvisorRepository.Save(advisor);

                /*var client = new Client
                {
                    PersonId = 2,
                    PersonName = "Mr Client2",
                    ClientRegistrationNumber = "CL2ABC123"
                };

                var account = new Account
                {
                     AccountNumber = "FN3CL3A124",
                     AccountFund = 100000,
                     FinancialAdvisor = advisor,
                     Client = client
                };                               
                                
                session.Store(account);
                string accountId = session.Advanced.GetDocumentId(account);*/
//session.SaveChanges();

                //List<FinancialAdvisor> advisors = session.Query<FinancialAdvisor>().ToList();
                //Account account1 = session.Load<Account>(accountId);


