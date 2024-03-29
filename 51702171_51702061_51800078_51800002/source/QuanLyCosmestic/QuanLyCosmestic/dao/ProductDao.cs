﻿using QuanLyCosmestic.database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCosmestic.dao
{
    class ProductDao
    {
        private helper.ProductHelper product_helper;
        private static ProductDao instance;
        private static readonly object padlock = new object();
        private DatabaseFactory df = new DatabaseMySql();

        private ProductDao()
        {
            product_helper = helper.ProductHelper.getInstance();
        }

        //Signleton
        public static ProductDao getInstance()
        {
            if (instance == null)
            {
                //lock == synchronized
                lock (padlock)
                {
                    instance = new ProductDao();
                }
            }
            return instance;
        }

        public DataTable loadData()
        {
            String sql = "select * from PRODUCT ORDER BY AMOUNT ASC";
            return product_helper.loadData(sql);
        }

        public DataTable loadDataSomething()
        {
            String sql = "select ID_PRODUCT, NAME_PRODUCT, SPECIFICATION, PRICE from PRODUCT";
            return product_helper.loadData(sql);
        }

        public bool updateAmountProduct(String id, int amountOld, int amountNew)
        {
            String sql = "update PRODUCT set AMOUNT = AMOUNT - @amountOld + @amountNew where ID_PRODUCT like @id ";

            DbParameter param1 = df.createParam("@id", id);
            DbParameter param2 = df.createParam("@amountOld", amountOld);
            DbParameter param3 = df.createParam("@amountNew", amountNew);

            DbParameter[] parameters = { param1, param2, param3};

            int rows = product_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //Add new Product
        public bool addProduct(model.Product product)
        {
            String sql = "insert into PRODUCT values(@idProduct, @nameProduct, @specification, @amount, @price, @idCategory)";

            DbParameter param1 = df.createParam("@idProduct", product.id_product);
            DbParameter param2 = df.createParam("@nameProduct", product.name_product);
            DbParameter param3 = df.createParam("@specification", product.specification);
            DbParameter param4 = df.createParam("@amount", product.amount);
            DbParameter param5 = df.createParam("@price", product.price);
            DbParameter param6 = df.createParam("@idCategory", product.id_category);

            DbParameter[] parameters = { param1, param2, param3, param4, param5, param6 };

            int rows = product_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //update product by idProduct
        public bool updateById(model.Product product, String idOld)
        {
            String sql = "update PRODUCT set ID_PRODUCT = @idProduct, NAME_PRODUCT = @nameProduct, SPECIFICATION = @specification " +
                          ",AMOUNT = @amount, PRICE = @price, ID_CATEGORY = @idCategory where ID_PRODUCT like @idOld ";

            DbParameter param1 = df.createParam("@idProduct", product.id_product);
            DbParameter param2 = df.createParam("@nameProduct", product.name_product);
            DbParameter param3 = df.createParam("@specification", product.specification);
            DbParameter param4 = df.createParam("@amount", product.amount);
            DbParameter param5 = df.createParam("@price", product.price);
            DbParameter param6 = df.createParam("@idCategory", product.id_category);
            DbParameter param7 = df.createParam("@idOld", idOld);
            DbParameter[] parameters = { param1, param2, param3, param4, param5, param6, param7 };

            int rows = product_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //Delete Product by id
        public bool deleteById(String id)
        {
            String sql = "delete from Product where ID_PRODUCT like @id";

            DbParameter param1 = df.createParam("@id", id);
            DbParameter[] parameters = { param1 };

            int rows = product_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }
    }
}
