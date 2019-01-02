using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CG.NET.DB
{
    public class SQLStr
    {
        public const string MSSQLDatatables = @"SELECT Name FROM Master..SysDatabases ORDER BY Name";


        public const string MSSQLTables = @"USE {0}
                                       SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_CATALOG='{0}' and TABLE_TYPE='BASE TABLE' ORDER BY TABLE_NAME";


        public const string MESQLColumns = @"USE {0}
                                        select 
                                        c.name as [Name],
                                        t.name as [Type],
                                        c.length as [Length],
                                        c.xprec as [Prec],
                                        c.xscale as [Scale],
                                        c.isnullable as [IsNull],
                                        ISNULL((select 1 from sysobjects b where b.parent_obj=o.id and b.xtype='pk' and b.uid=c.colid),0) as [PrimaryKey],
                                        (select text from syscomments m where m.id=c.cdefault) as [Default],
                                        (select top 1 p.value from sys.extended_properties p where c.id=p.major_id and c.colid=p.minor_id ) as [Description],
                                        o.name as TableName                                        
                                        from syscolumns c
                                        inner join systypes t on c.xtype= t.xtype
                                        inner join sysobjects o on c.id= o.id
                                        where   (o.xtype='u' OR o.xtype='U') And o.name='{1}' and t.name not in('sysname','IDate','IInt','ITime','VAcco','VCode','VGroup','VName','VPass','VSeat')
                                        order by c.colid";

        public const string MSSQLAllColumns = @"USE {0}
                                    select 
                                    c.name as [Name],
                                    t.name as [Type],
                                    c.length as [Length],
                                    c.xprec as [Prec],
                                    c.xscale as [Scale],
                                    c.isnullable as [IsNull],
                                    ISNULL((select 1 from sysobjects b where b.parent_obj=o.id and b.xtype='pk' and b.uid=c.colid),0) as [PrimaryKey],
                                    (select text from syscomments m where m.id=c.cdefault) as [Default],
                                    (select top 1 p.value from sys.extended_properties p where c.id=p.major_id and c.colid=p.minor_id ) as [Description],
                                    o.name as TableName
                                    from syscolumns c
                                    inner join systypes t on c.xtype= t.xtype
                                    inner join sysobjects o on c.id= o.id
                                    where   (o.xtype='u' OR o.xtype='U') 
                                    And o.name in (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_CATALOG='{0}' and TABLE_TYPE='BASE TABLE')
                                     and t.name not in('sysname','IDate','IInt','ITime','VAcco','VCode','VGroup','VName','VPass','VSeat')
                                    order by c.colid";


        public const string ORACLEDatatables = @"select tablespace_name from user_tablespaces";


        public const string ORACLETables = @"select TABLE_NAME from all_tables t where t.OWNER='{0}'";

        public const string ORACLEColumns = @"select 
                        c.COLUMN_NAME Name,
                        c.DATA_TYPE TYPE,
                        c.DATA_LENGTH Length,
                        c.DATA_PRECISION Prec,
                        c.DATA_SCALE Scale,
                        c.nullable IsNull,
                        (select p.constraint_name from all_constraints p,all_cons_columns a
                        where a.Table_Name=c.Table_Name 
                        and a.COLUMN_NAME=c.COLUMN_NAME
                        and a.owner=c.owner
                        and p.constraint_name = a.constraint_name 
                        and p.constraint_type = 'P')PrimaryKey,
                        c.data_default "+ "\"Default\"" + @",
                        (select COMMENTS from all_col_comments d where c.Table_Name=d.Table_Name and d.owner= c.owner and d.COLUMN_NAME= c.COLUMN_NAME) Description,
                        c.Table_Name TableName
                        from all_tab_columns c
                        where c.Table_Name='{1}'
                        and c.owner='{0}'
                        ";

        public const string ORACLEAllColumns = @"select 
                        c.COLUMN_NAME Name,
                        c.DATA_TYPE TYPE,
                        c.DATA_LENGTH Length,
                        c.DATA_PRECISION Prec,
                        c.DATA_SCALE Scale,
                        c.nullable IsNull,
                        (select p.constraint_name from all_constraints p,all_cons_columns a
                        where a.Table_Name=c.Table_Name 
                        and a.COLUMN_NAME=c.COLUMN_NAME
                        and a.owner=c.owner
                        and p.constraint_name = a.constraint_name 
                        and p.constraint_type = 'P')PrimaryKey,
                        c.data_default " + "\"Default\"" + @",
                        (select COMMENTS from all_col_comments d where c.Table_Name=d.Table_Name and d.owner= c.owner and d.COLUMN_NAME= c.COLUMN_NAME) Description,
                        c.Table_Name TableName
                        from all_tab_columns c
                        where c.Table_Name in (select TABLE_NAME from all_tables t where t.OWNER=c.owner)
                        and c.owner='{0}'
                        ";

    }
}