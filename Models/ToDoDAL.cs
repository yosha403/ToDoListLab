using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListLab.Models
{
    public class ToDoDAL
    {
        public List<ToDo> GetToDos()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "select * from ToDo";
                connect.Open();
                List<ToDo> toDos = connect.Query<ToDo>(sql).ToList();
                connect.Close();
                return toDos;
            }
        }

        public ToDo GetToDo(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "select * from todo where id=" + id;
                connect.Open();
                ToDo toDo = connect.Query<ToDo>(sql).ToList().First();
                connect.Close();
                return toDo;
            }
        }
        public void AddToDo(ToDo t)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"insert into todo values(0, '{t.Name}', {t.HoursNeeded}, {t.IsCompleted})";
                connect.Open();
                connect.Query<ToDo>(sql);
                connect.Close();
            }
        }
        public void DeleteToDo(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"delete from todo where id=" + id;
                connect.Open();
                connect.Query<ToDo>(sql);
                connect.Close();
            }
        }
        public void UpdateToDo(ToDo t)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"update todo set `name`='{t.Name}', hoursneeded= {t.HoursNeeded}, iscompleted={t.IsCompleted} where id=" + t.Id;
                connect.Open();
                connect.Query<ToDo>(sql);
                connect.Close();
            }
        }

    }
}
