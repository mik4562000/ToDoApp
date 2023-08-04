using MySql.Data.MySqlClient;
using toDoListManagement.Models;
using toDoListManagement.Repositories.Contracts;
using System.Data;

namespace toDoListManagement.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ILogger<ToDoRepository> _logger;
        private readonly string _connString;
        public ToDoRepository(ILogger<ToDoRepository> logger, IConfiguration config)
        {
            _logger = logger;
            _connString = config.GetConnectionString("DefaultConnection");
        }
        public List<ToDoItem> GetToDoItems(int statusId = 0)
        {
            using (var connect = new MySqlConnection(_connString))
            using (var cmd = connect.CreateCommand())
                try
                {
                    connect.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "todo.get_todo_items";

                    cmd.Parameters.Add("p_status_id", MySqlDbType.Int32).Value = statusId > 0 ? statusId : DBNull.Value;

                    var toDoList = new List<ToDoItem>();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            toDoList.Add(new ToDoItem
                            {
                                Id = dr.GetInt32("item_id"),
                                Name = dr.GetString("item_name").ToString(),
                                Status = new StatusInfo
                                {
                                    Id = dr.GetInt32("status_id"),
                                    Name = dr.GetString("status_name").ToString()
                                }
                            });
                        }
                    }
                    return toDoList;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    throw;
                }
        }

        public ToDoItem AddToDoItem(string name)
        {
            using (var connect = new MySqlConnection(_connString))//BaseOptions.strConnect
            using (var cmd = connect.CreateCommand())
                try
                {
                    connect.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "todo.create_todo_item";
                    cmd.Transaction = connect.BeginTransaction();

                    cmd.Parameters.Add("p_item_name", MySqlDbType.String).Value = name;
                    var itemIdParam = new MySqlParameter("p_item_id", MySqlDbType.Int32);
                    itemIdParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(itemIdParam);
                    var statusIdParam = new MySqlParameter("p_status_id", MySqlDbType.Int32);
                    statusIdParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(statusIdParam);
                    var statusNameParam = new MySqlParameter("p_status_name", MySqlDbType.String);
                    statusNameParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(statusNameParam);

                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();

                    return new ToDoItem
                    {
                        Id = (int)itemIdParam.Value,
                        Name = name,
                        Status = new StatusInfo
                        {
                            Id = (int)statusIdParam.Value,
                            Name = statusNameParam.Value.ToString()
                        }
                    };
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    throw;
                }
        }
        public void ChangeToDoItem(int id, string name)
        {
            using (var connect = new MySqlConnection(_connString))
            using (var cmd = connect.CreateCommand())
                try
                {
                    connect.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "todo.change_todo_item";
                    cmd.Transaction = connect.BeginTransaction();

                    cmd.Parameters.Add("p_item_id", MySqlDbType.Int32).Value = id;
                    cmd.Parameters.Add("p_item_name", MySqlDbType.String).Value = name;

                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    throw;
                }
        }
        public StatusInfo CompleteToDoItem(int id)
        {
            using (var connect = new MySqlConnection(_connString))
            using (var cmd = connect.CreateCommand())
                try
                {
                    connect.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "todo.complete_todo_item";
                    cmd.Transaction = connect.BeginTransaction();

                    cmd.Parameters.Add("p_item_id", MySqlDbType.Int32).Value = id;
                    var statusIdParam = new MySqlParameter("p_status_id", MySqlDbType.Int32);
                    statusIdParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(statusIdParam);
                    var statusNameParam = new MySqlParameter("p_status_name", MySqlDbType.String);
                    statusNameParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(statusNameParam);

                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();

                    var status = new StatusInfo
                    {
                        Id = (int)statusIdParam.Value,
                        Name = statusNameParam.Value.ToString()
                    };
                    
                    return status;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    throw;
                }
            
        }
        public StatusInfo DeleteToDoItem(int id)
        {
            using (var connect = new MySqlConnection(_connString))
            using (var cmd = connect.CreateCommand())
                try
                {
                    connect.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "todo.delete_todo_item";
                    cmd.Transaction = connect.BeginTransaction();

                    cmd.Parameters.Add("p_item_id", MySqlDbType.Int32).Value = id;
                    var statusIdParam = new MySqlParameter("p_status_id", MySqlDbType.Int32);
                    statusIdParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(statusIdParam);
                    var statusNameParam = new MySqlParameter("p_status_name", MySqlDbType.String);
                    statusNameParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(statusNameParam);

                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();

                    var status = new StatusInfo
                    {
                        Id = (int)statusIdParam.Value,
                        Name = statusNameParam.Value.ToString()
                    };

                    return status;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    throw;
                }
        }
        public void RemoveToDoItemForGood(int id)
        {
            using (var connect = new MySqlConnection(_connString))
            using (var cmd = connect.CreateCommand())
                try
                {
                    connect.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "todo.remove_todo_item";
                    cmd.Transaction = connect.BeginTransaction();

                    cmd.Parameters.Add("p_item_id", MySqlDbType.Int32).Value = id;

                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    throw;
                }
        }

    }
}
