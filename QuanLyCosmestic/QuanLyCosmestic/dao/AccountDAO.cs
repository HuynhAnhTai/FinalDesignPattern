﻿using System;
using System.Data.SqlClient;
using QuanLyCosmestic.database;
using System.Data.Common;

namespace QuanLyCosmestic.dao
{
    class AccountDAO
    {
        private static AccountDAO instance;
        private helper.AccountHelper account_helper;
        private DatabaseFactory df = new DatabaseMySql();
        private static readonly object padlock = new object();

        private AccountDAO()
        {
            account_helper = helper.AccountHelper.getInstance();
        }

        //Signleton AccountDao
        public static AccountDAO getInstance()
        {
            if (instance == null)
            {
                //lock == synchronized
                lock (padlock)
                {
                    instance = new AccountDAO();
                }
            }        
            return instance;
        }

        //check Account Exits, trans sql to AccountHelper and check
        public Boolean checkAccountExist(String userName, String password)
        {
            String sql = "Select count(*) from ACCOUNT where USERNAME LIKE @userName and PASSWORD LIKE @password";

            //abstract factory
            DbParameter param1 = df.createParam("@userName", userName);
            DbParameter param2 = df.createParam("@password", password);

            DbParameter[] parameters = { param1, param2 };

            if (account_helper.checkAccountExistDB(sql, parameters))
            {
                setCurrentUser(userName);
                return true;
            }
            return false;
        }

        //set information to currentUser
        public void setCurrentUser(String userName)
        {
            String sql2 = "Select * from EMPLOYEE where USERNAME LIKE @userName";
            DbParameter param1 = df.createParam("@userName", userName);

            account_helper.selectCurrentUser(sql2, param1);
        }

        //get Password by userName
        public String getPassword(String userName)
        {
            String sql2 = "Select * from ACCOUNT where USERNAME LIKE @userName";
            DbParameter param1 = df.createParam("@userName", userName);

            return account_helper.getPasswordDB(sql2, param1);
        }

        //add Account
        public bool addAccount(model.Account account)
        {
            String sql = "insert into ACCOUNT values(@userName, @password)";

            DbParameter param1 = df.createParam("@userName", account.user_name);
            DbParameter param2 = df.createParam("@password", account.password);

            DbParameter[] parameters = { param1, param2 };

            int rows = account_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //delete account by user name
        public bool deleteByUserName(String userName)
        {
            String sql = "delete from ACCOUNT where USERNAME like @userName";

            DbParameter param1 = df.createParam("@userName", userName);
            DbParameter[] parameters = { param1 };

            int rows = account_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //update account by user name
        public bool updateByUserName(String userName, String password, String userNameOld)
        {
            String sql = "update ACCOUNT set USERNAME = @userName, PASSWORD = @password where USERNAME like @userNameOld ";

            DbParameter param1 = df.createParam("@userName", userName);
            DbParameter param2 = df.createParam("@password", password);
            DbParameter param3 = df.createParam("@userNameOld", userNameOld);
            DbParameter[] parameters = { param1, param2, param3 };

            int rows = account_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }
    }
}
