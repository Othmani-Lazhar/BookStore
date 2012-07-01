namespace BookStore.Data.Test
{
    using BookStore.Data.DataAccess.DataStore;
    using BookStore.Entites.Domain;
    using Xunit;

    public class AutherDataStoreTest : BaseTestClass
    {
        private AutherDataStore autherDataStore = new AutherDataStore();

        public AutherDataStoreTest()
        {
        }

        [Fact]
        public void AutherInsertTest()
        {
            object obj;

            obj = this.autherDataStore.Insert(new Auther
            {
                AutherName = "İBRAHİM ATAY",
                Bio = string.Empty,
            });

            bool result = int.Parse(obj.ToString()) > 0 ? true : false;

            Assert.True(result, "Kayıt Eklendi..");
        }

        [Fact]
        public void AutherDelete()
        {
            bool result = this.autherDataStore.Delete(this.autherDataStore.Load(1));

            Assert.True(result);
        }
    }
}
