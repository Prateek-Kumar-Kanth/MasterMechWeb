using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MasterMechPrj;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace MasterMechData
{
    public class Customer
    {
        [Display(Name = "Customer No")]
        public int mnCustomerNo { get; set; }

        [Display(Name = "First Name")]
        public string msCustFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string msCustLastName { get; set; }

        [Display(Name = "Mobile")]
        public string msCustMobile { get; set; }

        [Display(Name = "Email")]
        public string msCustEmail { get; set; }

        [Display(Name = "CustStatus")]
        public string msCustStatus { get; set; }

        [Display(Name = "Type")]
        public string msCustType { get; set; }

        [Display(Name = "Street")]
        public string msCustStreet { get; set; }

        [Display(Name = "Area")]
        public string msCustArea { get; set; }

        [Display(Name = "City")]
        public string msCustCity { get; set; }

        [Display(Name = "State")]
        public string msCustState { get; set; }

        [Display(Name = "Pincode")]
        public string msCustPincode { get; set; }

        [Display(Name = "Country")]
        public string msCustCountry { get; set; }

        [Display(Name = "GSTNo")]
        public string msCustGSTNo { get; set; }

        [Display(Name = "LastVisit")]
        public DateTime? mdCustLastVisit { get; set; }

        [Display(Name = "Remarks")]
        public string msCustRemarks { get; set; }

        [Display(Name = "Created")]
        public DateTime? mdCustCreated { get; set; }

        [Display(Name = "CreatedBy")]
        public string msCustCreatedBy { get; set; }

        [Display(Name = "Modified")]
        public DateTime? mdCustModified { get; set; }

        [Display(Name = "ModifiedBy")]
        public string msCustModifiedBy { get; set; }

        [Display(Name = "Deleted")]
        public char mcCustDeleted { get; set; }


        [Display(Name = "DeletedOn")]
        public DateTime? mdDeletedOn { get; set; }

        [Display(Name = "CustDeletedBy")]
        public string mcCustDeletedBy { get; set; }

        public string msConnStr;

        public static string UserName { get; set; }
        public Customer() 
        {
            UserName = MasterMechUtil.msUserName;
            msConnStr = "Data Source=SOI\\SQLEXPRESS;Initial Catalog=MasterMech;Integrated Security=True";
           

        }
        public bool SearchUniqueID(string iCustMobNo)
        {
            try
            {

                //string lsConString = "Data Source=SOI\\SQLEXPRESS;Initial Catalog=MasterMech;Integrated Security=True";
                SqlConnection lObjCon = new SqlConnection(msConnStr);
                lObjCon.Open();
                string lsQuery = $"Select *from Customer Where CustMobNo = '{iCustMobNo}'";
                SqlCommand lObjCmd = new SqlCommand(lsQuery, lObjCon);
                SqlDataReader lObjReader = lObjCmd.ExecuteReader();

                if (lObjReader.HasRows)
                {
                    return true;
                }

                lObjCon.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }
        public Customer SearchSingleRecord(int inCustNo)
        {

            string query = $"SELECT * FROM Customer Where CustNo =  '{inCustNo}' and Deleted = 'N'";

            using (SqlConnection connection = new SqlConnection(msConnStr))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            mnCustomerNo = Convert.ToInt32(reader["CustNo"]);
                            msCustFirstName = reader["CustFName"].ToString();
                            msCustLastName = reader["CustLName"].ToString();
                            msCustMobile = reader["CustMobNo"].ToString();
                            msCustEmail = reader["CustEmail"].ToString();
                            msCustStatus = reader["CustSts"].ToString();
                            msCustType = reader["CustType"].ToString();
                            msCustStreet = reader["CustStAddr"].ToString();
                            msCustArea = reader["CustArAddr"].ToString();
                            msCustCity = reader["CustCity"].ToString();
                            msCustState = reader["CustState"].ToString();
                            msCustPincode = reader["CustPinCode"].ToString();
                            msCustCountry = reader["CustCountry"].ToString();
                            msCustGSTNo = reader["CustGSTNo"].ToString();
                            mdCustLastVisit = reader["CustLastVisit"] != DBNull.Value ? (DateTime)reader["CustLastVisit"] : (DateTime?)null;

                            msCustRemarks = reader["CustRemarks"].ToString();

                            mdCustCreated = reader["Created"] != DBNull.Value ? (DateTime)reader["Created"] : (DateTime?)null;

                            msCustCreatedBy = reader["CreatedBy"].ToString();

                            mdCustModified = reader["Modified"] != DBNull.Value ? (DateTime)reader["Modified"] : (DateTime?)null;
                            msCustModifiedBy = reader["ModifiedBy"].ToString();

                            mcCustDeleted = Convert.ToChar(reader["Deleted"]);
                            mdDeletedOn = reader["DeletedOn"] != DBNull.Value ? (DateTime)reader["DeletedOn"] : (DateTime?)null;

                            mcCustDeletedBy = reader["DeletedBy"].ToString();


                        }
                    }
                }
            }
            return this;


        }
        public List<Customer> ListData(string isMobileNo)
        {
            List<Customer> ListRecordsMatched = new List<Customer>();

            string query = $"SELECT * FROM Customer WHERE CustMobNo Like '{isMobileNo}%' and Deleted = 'N'";

            using (SqlConnection connection = new SqlConnection(msConnStr))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer lObjUser = new Customer();

                            lObjUser.mnCustomerNo = (int)(reader["CustNo"]);
                            lObjUser.msCustFirstName = reader["CustFName"].ToString();

                            lObjUser.msCustLastName = reader["CustLName"].ToString();
                            lObjUser.msCustMobile = reader["CustMobNo"].ToString();
                            lObjUser.msCustEmail = reader["CustEmail"].ToString();
                            lObjUser.msCustStatus = reader["CustSts"].ToString();
                            lObjUser.msCustType = reader["CustType"].ToString();
                            lObjUser.msCustStreet = reader["CustStAddr"].ToString();
                            lObjUser.msCustArea = reader["CustArAddr"].ToString();
                            lObjUser.msCustCity = reader["CustCity"].ToString();
                            lObjUser.msCustState = reader["CustState"].ToString();
                            lObjUser.msCustPincode = reader["CustPinCode"].ToString();
                            lObjUser.msCustCountry = reader["CustCountry"].ToString();
                            lObjUser.msCustGSTNo = reader["CustGSTNo"].ToString();
                         
                            lObjUser.mdCustLastVisit = reader["CustLastVisit"] != DBNull.Value ? (DateTime)reader["CustLastVisit"] : (DateTime?)null;

                            lObjUser.msCustRemarks = reader["CustRemarks"].ToString();
                            lObjUser.mdCustCreated = (DateTime)reader["Created"];
                            lObjUser.msCustCreatedBy = reader["CreatedBy"].ToString();
                            lObjUser.mdCustModified = reader["Modified"] != DBNull.Value ? (DateTime)reader["Modified"] : (DateTime?)null;


                            lObjUser.msCustModifiedBy = reader["ModifiedBy"].ToString();
                            //lObjUser.mcCustDeleted = (char)reader["Deleted"];
                            //lObjUser.mdDeletedOn = (DateTime)(reader["DeletedOn"]);
                            //lObjUser.mcCustDeletedBy = reader["DeletedBy"].ToString();

                            
                            ListRecordsMatched.Add(lObjUser);
                        }
                    }
                }
            }
            return ListRecordsMatched;


        }

        public List<Customer> AdvanceSearch(string isFName, string isLName, string isCity)
        {
            List<Customer> ListRecordsMatched = new List<Customer>();

            string query = $"SELECT * FROM Customer WHERE CustFName Like '{isFName}%' and CustLName Like '{isLName}%' and CustCity Like '{isCity}%' and Deleted = 'N'";

            using (SqlConnection connection = new SqlConnection(msConnStr))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer lObjUser = new Customer();

                            lObjUser.mnCustomerNo = (int)(reader["CustNo"]);
                            lObjUser.msCustFirstName = reader["CustFName"].ToString();

                            lObjUser.msCustLastName = reader["CustLName"].ToString();
                            lObjUser.msCustMobile = reader["CustMobNo"].ToString();
                            lObjUser.msCustEmail = reader["CustEmail"].ToString();
                            lObjUser.msCustStatus = reader["CustSts"].ToString();
                            lObjUser.msCustType = reader["CustType"].ToString();
                            lObjUser.msCustStreet = reader["CustStAddr"].ToString();
                            lObjUser.msCustArea = reader["CustArAddr"].ToString();
                            lObjUser.msCustCity = reader["CustCity"].ToString();
                            lObjUser.msCustState = reader["CustSts"].ToString();
                            lObjUser.msCustPincode = reader["CustPinCode"].ToString();
                            lObjUser.msCustCountry = reader["CustCountry"].ToString();
                            lObjUser.msCustGSTNo = reader["CustGSTNo"].ToString();
                            lObjUser.mdCustLastVisit = (DateTime)reader["CustLastVisit"];
                            lObjUser.msCustRemarks = reader["CustRemarks"].ToString();
                            lObjUser.mdCustCreated = (DateTime)reader["Created"];
                            lObjUser.msCustCreatedBy = reader["CreatedBy"].ToString();
                            lObjUser.mdCustModified = (DateTime)reader["Modified"];
                            lObjUser.msCustModifiedBy = reader["ModifiedBy"].ToString();
                            //lObjUser.mcCustDeleted = (char)reader["Deleted"];
                            //lObjUser.mdDeletedOn = (DateTime)(reader["DeletedOn"]);
                            //lObjUser.mcCustDeletedBy = reader["DeletedBy"].ToString();


                            ListRecordsMatched.Add(lObjUser);
                        }
                    }
                }
            }
            return ListRecordsMatched;

        }
        public void DeleteData(int isCustNo)
        {
            try
            {

                //string lsConString = "Data Source=SOI\\SQLEXPRESS;Initial Catalog=MasterMech;Integrated Security=True";
                SqlConnection lObjCon = new SqlConnection(msConnStr);
                lObjCon.Open();

                // No data is exactly deleted it is available for auditing purpose so you cannot delete it, only change the status
                string lsQuery = "Update Customer Set ";
                lsQuery += "Deleted = @Deleted, ";
                lsQuery += "DeletedOn = @DeletedOn, ";
                lsQuery += "DeletedBy = @DeletedBy ";
                lsQuery += "Where CustNo = @CustNo and Deleted = 'N'";

                SqlCommand lObjCmd = new SqlCommand(lsQuery, lObjCon);

                lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.Char).Value = 'Y';
                lObjCmd.Parameters.AddWithValue("@DeletedOn", SqlDbType.Time).Value = DateTime.Now;
                lObjCmd.Parameters.AddWithValue("@DeletedBy", SqlDbType.VarChar).Value = UserName; //This UserName Value is accessed From User.cs class File
                lObjCmd.Parameters.AddWithValue("@CustNo", SqlDbType.Int).Value = isCustNo;


                SqlDataReader lObjReader = lObjCmd.ExecuteReader();

                int lnRowsAffected = lObjReader.RecordsAffected;
                if (lnRowsAffected > 0)
                    MessageBox.Show("Deleted Successfully");
                else
                    MessageBox.Show("No Such Record");     //Reader.HasRows is not working why

                lObjCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool SaveSQL(MasterMechUtil.OPMode iMode)
        {
            string lsQueryText = "";
            string msConnStr = "Data Source=SOI\\SQLEXPRESS;Initial Catalog=MasterMech;Integrated Security=True";
            bool lbOpType = false;
            using (SqlConnection lObjConn = new SqlConnection(msConnStr))
            {
                if (iMode == MasterMechUtil.OPMode.New)
                {
                    lsQueryText = "INSERT INTO Customer(CustFName, CustLName, CustMobNo, CustEmail, CustSts, CustType, CustStAddr, CustArAddr, CustCity, CustState, CustPinCode, CustCountry, CustGSTNo, CustLastVisit, CustRemarks, Created, CreatedBy, Modified, ModifiedBy, Deleted, DeletedOn, DeletedBy) Values";
                    lsQueryText += "(@CustFName, @CustLName, @CustMobNo, @CustEmail, @CustSts, @CustType, @CustStAddr, @CustArAddr, @CustCity, @CustState, @CustPinCode, @CustCountry, @CustGSTNo, NULL, @CustRemarks, @Created, @CreatedBy, NULL, NULL, 'N', NULL, 'N')";
                    MessageBox.Show("Inserted Successfully");
                }
                else if (iMode == MasterMechUtil.OPMode.Open)
                {
                   
                    lsQueryText = "UPDATE Customer SET ";
                    lsQueryText += "CustFName=@CustFName,";
                    lsQueryText += "CustLName=@CustLName,";
                    lsQueryText += "CustMobNo=@CustMobNo,";
                    lsQueryText += "CustEmail=@CustEmail,";
                    lsQueryText += "CustSts=@CustSts,";
                    lsQueryText += "CustType=@CustType,";
                    lsQueryText += "CustStAddr=@CustStAddr,";
                    lsQueryText += "CustArAddr=@CustArAddr,";
                    lsQueryText += "CustCity=@CustCity,";
                    lsQueryText += "CustState=@CustState,";
                    lsQueryText += "CustPinCode=@CustPinCode,";
                    lsQueryText += "CustCountry=@CustCountry,";
                    lsQueryText += "CustGSTNo=@CustGSTNo,";
                   
                    lsQueryText += "CustRemarks=@CustRemarks,";
                   
                    lsQueryText += "Modified=@Modified,";
                    lsQueryText += "ModifiedBy=@ModifiedBy ";
                    lsQueryText += "where CustNo=@CustNo ";


                    MessageBox.Show("Updated Successfully");
                }
                using (SqlCommand cmd = new SqlCommand(lsQueryText, lObjConn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@CustNo", SqlDbType.VarChar).Value = mnCustomerNo;
                        cmd.Parameters.AddWithValue("@CustFName", SqlDbType.VarChar).Value = msCustFirstName;
                        cmd.Parameters.AddWithValue("@CustLName", SqlDbType.VarChar).Value = msCustLastName;
                        cmd.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = msCustMobile;
                        cmd.Parameters.AddWithValue("@CustEmail", SqlDbType.VarChar).Value = msCustEmail;
                        cmd.Parameters.AddWithValue("@CustSts", SqlDbType.VarChar).Value = msCustStatus;
                        cmd.Parameters.AddWithValue("@CustType", SqlDbType.VarChar).Value = msCustType;
                        cmd.Parameters.AddWithValue("@CustStAddr", SqlDbType.Time).Value = msCustStreet;
                        cmd.Parameters.AddWithValue("@CustArAddr", SqlDbType.Time).Value = msCustArea;
                        cmd.Parameters.AddWithValue("@CustCity", SqlDbType.VarChar).Value = msCustCity;
                        cmd.Parameters.AddWithValue("@CustState", SqlDbType.Time).Value = msCustState;
                        cmd.Parameters.AddWithValue("@CustPinCode", SqlDbType.Time).Value = msCustPincode;
                        cmd.Parameters.AddWithValue("@CustCountry", SqlDbType.VarChar).Value = msCustCountry;
                        cmd.Parameters.AddWithValue("@CustGSTNo", SqlDbType.VarChar).Value = msCustGSTNo;
                        
                        cmd.Parameters.AddWithValue("@CustRemarks", SqlDbType.VarChar).Value = msCustRemarks;

                        if (iMode == MasterMechUtil.OPMode.New)
                        {
                            cmd.Parameters.AddWithValue("@Created", SqlDbType.VarChar).Value = DateTime.Now;
                            cmd.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = MasterMechUtil.msUserName;
                        }
                        
                        cmd.Parameters.AddWithValue("@Modified", SqlDbType.VarChar).Value = DateTime.Now;
                        cmd.Parameters.AddWithValue("@ModifiedBy", SqlDbType.VarChar).Value = MasterMechUtil.msUserName;

                        lObjConn.Open();
                        cmd.ExecuteNonQuery();
                        lObjConn.Close();
                        lbOpType = true;
                        //return true;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        //return false;
                    }


                }
            }
            return lbOpType;
        }

    }
}
