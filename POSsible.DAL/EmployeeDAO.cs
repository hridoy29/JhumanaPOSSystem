using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using POSsible.BusinessObjects;

namespace POSsible.DAL
{
    public class EmployeeDAO
    {
        public EmployeeDAO()
        {
            DbProviderHelper.GetConnection();
        }

        private static void BuildEntity(DbDataReader oDbDataReader, Employee oEmployee)
        {
            DataTable dt = oDbDataReader.GetSchemaTable();
            foreach (DataRow item in dt.Rows)
            {
                string col = item.ItemArray[0].ToString();
                switch (col)
                {
                    case "EmployeeId":
                        oEmployee.EmployeeId = Convert.ToInt32(oDbDataReader["EmployeeId"]);
                        break;
                    case "EmployeeName":
                        oEmployee.EmployeeName = Convert.ToString(oDbDataReader["EmployeeName"]);
                        break;
                    case "ShortName":
                        oEmployee.ShortName = Convert.ToString(oDbDataReader["ShortName"]);
                        break;
                    case "IsActive":
                        oEmployee.IsActive = Convert.ToBoolean(oDbDataReader["IsActive"]);
                        oEmployee.IsActiveString = oEmployee.IsActive ? "Yes" : "No";
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddParameter(DbCommand oDbCommand, string parameterName, DbType dbType, object value)
        {
            oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(parameterName, dbType, value));
        }

        public List<Employee> Employee_GetAll()
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<Employee> lstEmployee = new List<Employee>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Employee_GetAll2", CommandType.StoredProcedure);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    Employee oEmployee = new Employee();
                    BuildEntity(oDbDataReader, oEmployee);
                    lstEmployee.Add(oEmployee);
                }
                return lstEmployee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!oDbDataReader.IsClosed)
                {
                    oDbDataReader.Close();
                    oDbDataReader.Dispose();
                }
            }
        }

        public List<Employee> Employee_GetDynamic(string WhereCondition, string OrderByExpression)
        {
            DbDataReader oDbDataReader = null;
            try
            {
                List<Employee> lstEmployee = new List<Employee>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Employee_GetDynamic", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@WhereCondition", DbType.String, WhereCondition);
                AddParameter(oDbCommand, "@OrderByExpression", DbType.String, OrderByExpression);
                oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    Employee oEmployee = new Employee();
                    BuildEntity(oDbDataReader, oEmployee);
                    lstEmployee.Add(oEmployee);
                }
                return lstEmployee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!oDbDataReader.IsClosed)
                {
                    oDbDataReader.Close();
                    oDbDataReader.Dispose();
                }
            }
        }

        public int Add(Employee _Employee)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Employee_Create", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@EmployeeName", DbType.String, _Employee.EmployeeName);
                AddParameter(oDbCommand, "@IsActive", DbType.Boolean, _Employee.IsActive);

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(Employee _Employee)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Employee_Update", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@EmployeeName", DbType.String, _Employee.EmployeeName);
                AddParameter(oDbCommand, "@IsActive", DbType.Boolean, _Employee.IsActive);
                AddParameter(oDbCommand, "@EmployeeId", DbType.Int32, _Employee.EmployeeId);

                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Error in Update.", "LPOS");
                throw;
            }
        }

        public int Delete(int employeeId)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("Employee_DeleteById", CommandType.StoredProcedure);
                AddParameter(oDbCommand, "@EmployeeId", DbType.Int32, employeeId);
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
