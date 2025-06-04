using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTasks
{
    public abstract class User
    {
        [Key]
        Guid Id { get; set; }
        string Name { get; set; }
        string Password { get; set; }

    }
    public interface IRepository
    {
        public Task<User> GetUser(Guid id);
    }

    class Deadlock
    {
        private readonly IRepository _repos;

        public Deadlock(IRepository repos)
        {
            _repos = repos;
        }

        public void DoSomethingWrong(Guid id) // НЕПРАВИЛЬНО user.Result может заблокировать контекст
                                              // и ждать завершения работы GetUser,
                                              // а GetUser может вернуться в заблокированный контекст и
                                              // ждать его разблокировки - deadlock
        {
            var user = _repos.GetUser(id);

            // Какая-то логика

            Console.WriteLine(user.Result);
        }

        public async Task DoSomethingCorrect(Guid id) // await дает гарантию того,
                                                      // что при вызове Console.WriteLine GetUser отработает
        {
            var user = await _repos.GetUser(id);

            // Какая-то логика

            Console.WriteLine(user);
        }
    }
}
