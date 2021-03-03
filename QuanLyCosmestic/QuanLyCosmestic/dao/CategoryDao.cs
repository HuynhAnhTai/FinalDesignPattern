using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCosmestic.dao
{
    class CategoryDao
    {
        private helper.CategoryHelper category_helper;
        private static CategoryDao instance;
        private static readonly object padlock = new object();

        private CategoryDao()
        {
            category_helper = helper.CategoryHelper.getInstance();
        }

        //Signleton
        public static CategoryDao getInstance()
        {
            if (instance == null)
            {
                //lock == synchronized
                lock (padlock)
                {
                    instance = new CategoryDao();
                }
            }
            return instance;
        }

        public DataTable loadData()
        {
            String sql = "select * from CATEGORY";
            return category_helper.loadData(sql);
        }

        //Add new Category
        public bool addCategory(model.Category category)
        {
            String sql = "insert into CATEGORY values(@nameCategory)";

            SqlParameter param1 = new SqlParameter("@nameCategory", category.name_category);

            SqlParameter[] parameters = { param1 };

            int rows = category_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //update category by idProduct
        public bool updateById(model.Category category)
        {
            String sql = "update CATEGORY set NAME_CATEGORY = @nameCategory where ID_CATEGORY like @id ";

            SqlParameter param1 = new SqlParameter("@nameCategory", category.name_category);
            SqlParameter param2 = new SqlParameter("@id", category.id_category);
            SqlParameter[] parameters = { param1, param2 };

            int rows = category_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //Delete Product by id
        public bool deleteById(String id)
        {
            String sql = "delete from CATEGORY where ID_CATEGORY like @id";

            SqlParameter param1 = new SqlParameter("@id", id);
            SqlParameter[] parameters = { param1 };

            int rows = category_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

    }
}
