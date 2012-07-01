namespace BookStore.Core.Authentication
{
    using System.Web;
    using BookStore.Data.DataAccess.DataStore;
    using BookStore.Entites.Domain;
    using BookStore.Entites.Validator;

    public class MemberShip
    {
        private CoutomerDataStore coutomerDataStore = new CoutomerDataStore();

        public bool CoutomerLogin(string user, string password)
        {
            Coutomer ctomer = this.coutomerDataStore.GetCoutomer(user, password);

            if (ctomer != null)
            {
                HttpContext.Current.Session["ctomerid"] = ctomer.ID;
            }

            return false;
        }

        public void CoutomerLogout()
        {
            HttpContext.Current.Session.Abandon();
        }

        public bool RegisterCoutomer(Coutomer coutomer)
        {
            CoustomerValidation cvalidation = new CoustomerValidation();

            if (cvalidation.Validate(coutomer).IsValid)
            {
                this.coutomerDataStore.Insert(coutomer);

                return true;
            }

            return false;
        }
    }
}
