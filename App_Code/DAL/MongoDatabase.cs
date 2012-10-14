using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using System.Data;
using MongoDB.Bson;
using MongoDB.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Wrappers;
using MongoDB.Driver.Builders;
using System.Reflection;
using System.Collections;
/// <summary>
/// Summary description for MongoDB
/// </summary>
public class _MongoDatabase : DAC
{

    public _MongoDatabase()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    // TODO: Apply Singleton Pattern
    public override Object buildConnection()
    {
        MongoServer server = MongoServer.Create();
        MongoDatabase db = server.GetDatabase("SocialDB");
        return db;
    }

    private MongoCollection<BsonDocument> getobjCollection(string tableName)
    {
        var db = (MongoDatabase)this.buildConnection();
        MongoCollection<BsonDocument> objCollection = db.GetCollection<BsonDocument>(tableName);

        return objCollection;
    }

    public override string insert(Object objClass, string tableName)
    {
        string ret = String.Empty;
        MongoCollection<BsonDocument> objCollection = this.getobjCollection(tableName);

        BsonDocument doc = new BsonDocument();
        PropertyInfo[] _objProperties = objClass.GetType().GetProperties();

        string _name = String.Empty;
        string _val = String.Empty;
        foreach (PropertyInfo property in _objProperties)
        {
            if (property.CanRead)
            {
                _name = property.Name;
                _val = (string)property.GetValue(objClass, null);
                if (_val != null)
                {
                    if (_name == "Id" || _name == "UserId")
                    {
                        doc.Add(_name, ObjectId.Parse(_val));
                    }
                    else
                    {
                        doc.Add(_name, _val);
                    }
                }
            }
        }

        var rt = objCollection.Insert(doc);

        return doc["_id"].ToString();
    }

    public override bool update(Object objClass, string paramName, string paramVal, string tableName)
    {
        string ret = String.Empty;
        MongoCollection<BsonDocument> objCollection = this.getobjCollection(tableName);

        BsonDocument doc = new BsonDocument();
        var query = Query.EQ(paramName, ObjectId.Parse(paramVal));
        var sortBy = SortBy.Descending(paramName);
        PropertyInfo[] _objProperties = objClass.GetType().GetProperties();
        string _type = String.Empty;
        string _name = String.Empty;
        string _val = String.Empty;
        UpdateBuilder update = new UpdateBuilder();

        foreach (PropertyInfo property in _objProperties)
        {
            if (property.CanRead)
            {
                _name = property.Name;
                _val = (string)property.GetValue(objClass, null);
                if (_val != null)
                {
                    if (_name == "Id" || _name == "UserId")
                    {
                        update.Set(_name, ObjectId.Parse(_val));
                    }
                    else
                    {
                        update.Set(_name, _val);
                    }
                }
            }
        }

        var result = objCollection.FindAndModify(query, sortBy, update, true);
        return true;
    }

    public override bool delete(string pk, string tableName)
    {
        MongoCollection<BsonDocument> objCollection = this.getobjCollection(tableName);
        var result = objCollection.FindAndRemove(Query.EQ("_id", ObjectId.Parse(pk)), SortBy.Ascending("_id"));

        return true;
    }

    public override List<Object> getAll(string tableName)
    {
        List<Object> lst = new List<Object>();
        MongoCollection<BsonDocument> objCollection = this.getobjCollection(tableName);

        foreach (Object item in objCollection.FindAll())
        {
            lst.Add(item);

        }
        return lst;
    }

    public override Object getById(string pk, string tableName)
    {
        MongoCollection<BsonDocument> objCollection = this.getobjCollection(tableName);
        Object ret = null;
        foreach (Object item in objCollection.Find(Query.EQ("_id", ObjectId.Parse(pk))))
        {
            ret = item;
            break;
        }

        return ret;
    }

    public override ArrayList getByParam(string paramName, string paramVal, string tableName)
    {
        ArrayList Activities = new ArrayList();
        MongoCollection<BsonDocument> objCollection = this.getobjCollection(tableName);

        foreach (Object item in objCollection.Find(Query.EQ(paramName, ObjectId.Parse(paramVal))))
        {
            Activities.Add(item);
        }

        return Activities;
    }



}