using WebToDo.Models;

namespace WebToDo.Tests
{
    public class UsersTests
    {
        private readonly Users users;

        public UsersTests()
        {
            users = new Users();
        }

        [Fact]
        public void IsValidEmail_ReturnsTrue()
        {
            Assert.True(users.IsValidEmail("sobaka@gmail.com"));
            Assert.True(users.IsValidEmail("sobaka@gmail.ru"));
            Assert.True(users.IsValidEmail("sobaka@mail.ru"));
            Assert.True(users.IsValidEmail("sob.aka@gmail.com"));
            Assert.True(users.IsValidEmail("sob.aka@gm-ail.com"));
            Assert.True(!users.IsValidEmail("sob/2Aaka@gmail.com"));
        }

        [Fact]
        public void IsValidPassword_ReturnsTrue()
        {
            Assert.True(!users.IsValidPasword("123"));
            Assert.True(!users.IsValidPasword("1a3"));
            Assert.True(!users.IsValidPasword("12A"));
            Assert.True(!users.IsValidPasword("12."));
            Assert.True(!users.IsValidPasword("12342."));
            Assert.True(users.IsValidPasword("123Agsd"));
            Assert.True(users.IsValidPasword("qwerty123"));
            Assert.True(users.IsValidPasword("qwertY-1230"));
            Assert.True(users.IsValidPasword("qwertY-1230/"));
            Assert.True(!users.IsValidPasword("qwerty"));
            Assert.True(!users.IsValidPasword("qwe rty"));
            Assert.True(users.IsValidPasword("qwAer123ty"));
        }
    }
}
