using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CG.NET.DB
{
    public class SQLStr
    {
        public const string Datatables = "SELECT Name FROM Master..SysDatabases ORDER BY Name";


        public const string Tables = @"USE {0}
                                       SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_CATALOG='{0}' and TABLE_TYPE='BASE TABLE' ORDER BY TABLE_NAME";


        public const string Columns = @"USE {0}
                                        select 
                                        c.name as [Name],
                                        t.name as [Type],
                                        c.length as [Length],
                                        c.xprec as [Prec],
                                        c.xscale as [Scale],
                                        c.isnullable as [IsNull],
                                        ISNULL((select 1 from sysobjects b where b.parent_obj=o.id and b.xtype='pk' and b.uid=c.colid),0) as [PrimaryKey],
                                        (select text from syscomments m where m.id=c.cdefault) as [Default],
                                        (select top 1 p.value from sys.extended_properties p where c.id=p.major_id and c.colid=p.minor_id ) as [Description]
                                        from syscolumns c
                                        inner join systypes t on c.xtype= t.xtype
                                        inner join sysobjects o on c.id= o.id
                                        where   (o.xtype='u' OR o.xtype='U') And o.name='{1}' and t.name not in('sysname','IDate','IInt','ITime','VAcco','VCode','VGroup','VName','VPass','VSeat')
                                        order by c.colid";


    }
}