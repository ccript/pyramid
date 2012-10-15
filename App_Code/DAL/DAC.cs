using System.Data;
using System;
using System.Collections.Generic;
using System.Collections;

public abstract class DAC
{
    public string connectionString;    
    public abstract Object buildConnection();
    public abstract string insert(Object obj, string tableName);
    public abstract bool update(Object obj, string paramName, string paramVal, string tableName);
    public abstract bool delete(string pk, string tableName);
    public abstract Object getById(string pk, string tableName);
    public abstract List<Object> getAll(string tableName);
    public abstract ArrayList getByParam(string paramName, string paramVal, string tableName);    

}