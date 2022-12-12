using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Calculator
{
    class TableNames
    {
        string? name { get; set; }
    }
    internal class SqLite
    {
        private SQLiteAsyncConnection conn;
        private string directoryPath = "C:\\Users\\donth\\Sai";
        private string dbFileName = "history.db3";

        public async Task Init()
        {
            conn = new SQLiteAsyncConnection(Path.Combine(directoryPath,dbFileName));
            await CreateHistoryTable();
            
        }
        private async Task CreateHistoryTable()
        {
            try
            {
                List<TableNames> result = await conn.QueryAsync<TableNames>("SELECT name FROM sqlite_master WHERE type='table' AND name='Operation';");
                if (result.Count == 0)
                {
                    await conn.CreateTableAsync<Operation>();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public async Task<List<Operation>> GetAllOperations()
        {
            try
            {
                return await conn.Table<Operation>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Failed to retrieve data. {0}", ex.Message));
            }

            return new List<Operation>();
        }
        public async Task AddNewOperation(Operation op)
        {
            int result = 0;
            try
            {
                result = await conn.InsertAsync(new Operation
                {
                    mathOperator = op.mathOperator,
                    result = op.result,
                    value1 = op.value1,
                    value2 = op.value2
                }) ;
                Console.WriteLine(string.Format("{0} record(s) added", result));
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Failed to add {0}.", ex.Message));
            }
        }
        public async Task<int> RemoveAll()
        {
            try
            {
                return await conn.ExecuteAsync("DELETE FROM Operation;");
            } 
            catch(Exception ex)
            {
                return 0;
            }
            
        }
    }
}
