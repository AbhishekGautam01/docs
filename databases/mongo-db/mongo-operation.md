#MongoDB 

##Section 7 - Read Operations
1. **Method, filter & Operators** <vid_80_1_25>

		

		db.movies.find({"rating.average": {$ge: 7}}) -> average is an embded feild in the document. 
		db.movies.find({"genres": "drama") -> where generes is arr, in that array drama is an element
		db.movies.find({"genres": ["drama"]) -> where generes is arr &  we are looking for exact arr match 
		db.movies.find({runtime: {$in: [all_accepted_values]}}) -> $nin - not in the set of mentioned value. 

	**Logical operator**
		db.movies.find({$or: [{"rating.average": {$lt: 5}}, {"rating.average": {$gt:9.3}}]}).pretty()
		we can give any number of filters and if any record match any one of them then it is selected. 
		$nor - not or - mean all record which doesnt match any of the provided filter
		db.movies.find($and: [{"rating.average": {$lt: 5}}, {"genres": "drama"}]).pretty()
		db.movies.find($not: [{"rating.average": {$lt: 5}}, {"genres": "drama"}]).pretty()

	**Element Operator**
		db.users.find({age:{$exist: true, $gt: 40}}) - all doc which have age feild
		db.users.find({age:{$exist: true, $ne: null}}).pretty() - all doc with age feild and value not null
		db.users.find({phone: {$type: "number"}}).prety() - all phone number where the type is number
		db.users.find({phone: {$type: ["number", "stering"]}}).prety() - all doc where type is num, str

	**regex operator**
		seach for text - but they are not super performance efficient 
		db.users.find({summary: {$regex:"regex_or_any_word"}}).pretty() 
	**expressions**
		where we want to compare two feilds and then select 
		db.sales.find({$expr:{$gt:["$volume", "$target"]}}).prety() -> this wil return volume > target 
		db.sales.find({$expr:{$gt:[{$cond: {if: {$gte: ["$volume", 190]}, then: {$substract: ["$volume", 10]}, else: "$volume"}}).prety()

	**Array Query Selector**
		db.users.find({hobbies: {$size: 3}}).pretty() - this has to be extact match in terms of number of records
		db.users.find({genre: {$all: ["action", "thriller"]}}) - this will say these two element exist even if order is different 
		db.users.find({hobbies: {$elemMatch: {tittle: "Sports", frequence: {gte: 3}}}}) 

	**Cursors** <vid_97:1:20>
		find() - yeild as a cursor 
		yeild records by requested batch size: we can chain cursors.  eg shell gives us by default 20 records
		db.movies.find()
		const dataCursor = db.movies.find()
		dataCursor.next() - gives the next element 
		dataCursor.forEach(doc => {pritnjson(doc)}) -> this will loop through doc which we havent looked yet. 
		dataCursor.hasNext() - tell if we have next data or not. 
		*sorting the cursor records* dataCursor.sort({"rating.average": 1}) -1 is desc and 1 is asc 
		> dataCursor.sort({"rating.average": 1, rating: -1}) - sorting by more by one doc property
		> dataCursor.sort({"rating.average": 1, rating: -1}).skip(number_of_records_skiped) - skip also works on cursor
		> dataCursor.sort({"rating.average": 1, rating: -1}).limit(10) - retrieve the certain amount of documentation. 
		The order of skip and sort and limit doesnt matter. 

	**Using Projections**
		db.movies.find({}, {name: 1, genres: 1, runtime: 1, rating: 1, image: 0 }).pretty() - all with 1 will get selected and mentioning with 0 is not mandatorty but we can do this. 
		we can also do this for the embeded documents. 
		*Projections in array*

	**$Slice** vid 103

##Section 8 - Update Operations 
1. updateOne(), updateMany() and $set
	for update we need the doc selection criteria and then the update records
	db.persons.updateOne({id: "1"}, {$set: {hobbies: ["", "", ""]}}) - this will add/edts 
	

##Section 10 - Indexes - createIndex({doc}) && dropIndex({doc})
1. Index can speed up all lookup queries. Without Index, to query mongo does collection scan. 
2. Index exist additionally, it is ordered list which allows to do index scan. Index has pointer to real element. 
3. Using too many index - as it may speed find query, but performance cost will comes on inserts
	__Single Feild Index__
	1. db.collectionName.<explain()>.find({"dob.age": {$gt: 60}})  - Mongo determines the plan to execute the query, out of these plans, one plan becomes winning plan & other becomes rejectedPlans, witout index we will have Full Collection scan as winning plan . explain gives other information, in it you can pass str "executionStat"
	2. *Adding Index*: db.collName.createIndex({"dob.age": 1}) ; 1 for asc order & -1 for desc order
	3. Index scan return the ptrs after which FETCH runs to get ptr and return document. 
	__Index Restrictions__
	1. When you have a query that returns a large portion or majority of document then index will be slower as you will go through all index list then additionaly use ptr to get all data so in such a case it becomes slower than the full collection scan 
	__Compound Index__
	1. bool dont make sense for index as we have only 2 values. you can do on number, text , dont do on enum types like gender as it will be very less type of value
	2. db.collname.createIndex({"prop1": 1, "prop2": 1}) - this  will create 1 index & not 2 will have prop1& prop2
	3. The above is called compound index. it will be take if you search using prop1 & prop2 or just for prop1, but if you search based on just prop2 then it will not be applicable.
	4. Limit for compound index is 31. 
	__Index for Sorting__
	1. db.collectionName.<explain()>.find({"dob.age": {$gt: 60}}) .sort({"gender": 1}) - for sorting IXScan will be used if index of gender 
	2. MOngo has threshold for 32MB memory for sorting after it will timeout - so here we can do indexing 
	__Default Index__
	1. db.collname.getIndexes() - gives default indexes - for every colled id is default index
	__Configuring Indexes__
	1. To add uniqueness for feild like emails we can create index 
		<db.collName.createIndex({email: 1}, {unique: true})>
	__Partial Indexes__
	1. Index take up size, the bigger index the more time some queries may take. 
	2. Add index on props which you are going to frequently used. 
	3. <db.collName.createIndex({"dob.age": 1}, {partialFilterExpression: {gender:"male"}})>
		this will create index on dob.age only for gender male. while executing a find, if we only find on dob.age then it will do full collection scan as gender is not male, but if we find on dob.age mentioning gender is male then IXSCAN will  happen. 
		partialFilterExpression can also be used compund indexes
	4. For partial index, the index size is smaller, as index is just for mail and also write becomes little faster. 
	5. Mongo DB treates non existing value still in index if on that column you have created index. for example, if you have created a index on email whihc is unique, then you can insert 1 doc without email, it will work, in index email will be considered as null, but insert another doc without email it will fail as with duplicate key exception. to fix this you can do 
	<db.collName.createIndex({email: 1}, {unique: true, partialFilterExpression: {email: {$exists: true}}})>
	here the index will be created on email if only if email exists in the document
	__Time-To-Live Index__
	1. Useful for self destroying data like session of users. It only works on single index & date object
	<db.collName.createIndex({createdAt: 1}, {expireAfterSeconds: 10}) - this works only for date feilds>
	__Query Diagonstics & Query Planning__
	1. explain() method, we can pass "queryPlan", "executionStats", "allPlanExecution"
	2. to compare performance - see milliseconds, See no of keys are examined, no of document examined or document returned
	__Covered Queries__
	1. Where totalDocsExamined is 0. when you return the feild on which index is created 
	2. Here query becomes fully accessible from index, then query will be super efficient. 
	__How Mongo Rejects a Plan__
	1. Mongo looks for indexes which can help for the query, then it checks that to let say fetch 100 records which one will be faster, that becomes winning plan, now since this would take performance, mongo caches the plan in memory as winning plan for that query & for future queries this plan is used, it is cleared after certain amount of document is insert or if we rebuild index or if we add a new indexes or when you restart mongodb server. 
	2. allPlanExecution in explain gives details for different indexes. 
	__Multi Key Indexes__ 
	1. Index on array values are multi key values, mongo pull out all values of aaray and store each of them in index, so this is bigger than other index, but it can be used if we query on these
	2. But write also be more time taking as new arr all value need to be indexes, but this is good for arr or embeded documents. 
	3. if we add multi key index in compound index - then coumpound index can't have 2 multi index feilds - as mongo will have to do cartersian product for those. 
	__text index__
	1. Regex has very low performance for searching text. better is used to text index, so it converts text to array of words, & removes all stop words (is , that, a) - keywords are stored. 
	2.  We can have only 1 text index in a collection but we can combine multiple feilds for that 1 text search feild. 
	3. db.products.find({$text: {$search: "awesome t-shirt"}}, {score: {$meta: "textScore"}})
		the above query will asign a score to each seached items, and sort desc on score
	4. db.collectionName.createIndex({prop1: "text", prop2: "text"})
	5. Default Language: is set to english, db.collectionName.createIndex({prop1: "text", prop2: "text"}, {default_language: "english"}) - there is a list of supported language - 
	6. we can set feild weights to give them priority:
		db.collectionName.createIndex({prop1: "text", prop2: "text"} ,{weights:{prop1: 1, prop2: 10}})
	__Building Indexes__
	1. Indexes can be created forground or background. & during creation the collection will be locked. and any ops during that will have to wait. for text index it might also take longer than this. 
	2. Foreground creation is faster. 
	3. db.collectionName.createIndex({prop1: "text", prop2: "text"}, {background: true}) - this is good for produ tion databases
	3. 

##Section 12 - Aggregation Framework 
1. Here we have a collection , the AF is pipeline of steps that run on a collection and then return you the data. 
	EG <collection -> match -> sort -> group -> project -> output data>
2. Aggregate takes array where series of data is defined. Every step is a document. 
In match we can filter in same as we used to do in find. 
3. After match we have group stage. This allows to group by a certain or multiple feilds. It takes first param as id. this defines which feild you wanna group on. 
	EG: db.persons.aggregate([
    {$match: {gender: "female"}},
    {$group: {_id: { state: "$location.state" }, totalPersons: { $sum: 1 } } }
    ]).pretty()
4. __Group By Examples__
Single Field Group By & Count:

db.Request.aggregate([
    {"$group" : {_id:"$source", count:{$sum:1}}}
])
Multiple Fields Group By & Count:

db.Request.aggregate([
    {"$group" : {_id:{source:"$source",status:"$status"}, count:{$sum:1}}}
])
Multiple Fields Group By & Count with Sort using Field:

db.Request.aggregate([
    {"$group" : {_id:{source:"$source",status:"$status"}, count:{$sum:1}}},
    {$sort:{"_id.source":1}}
])
Multiple Fields Group By & Count with Sort using Count:

db.Request.aggregate([
    {"$group" : {_id:{source:"$source",status:"$status"}, count:{$sum:1}}},
    {$sort:{"count":-1}}
])





##Mongo C# Driver Documentation 
https://mongodb.github.io/mongo-csharp-driver/2.1/reference/driver/

1. Connecting:
	1. **Connection String**: it follows RFC 3986
		1. <mongodb://host:27017> - to conn. to mul. for mongos or replica set - <mongodb://host1:27017,host2:27017>
			NOTE: While conn to replica set, include rep set name as conn string option,to skip _cluster discovery step_
		2. Database Component: <mongodb://host:27017/mydb>
		3. Mul. options can be passed as conn str param, those which cn't be pssd may be provided in _MongoClientSettings obj_ in C# while creating connection
		4. **Mongo Client**: thread-safe, root obj. Handles conn to server, monitoring & performing operations. 
			<var client = new MongoClient();> - w/o arg means conn to localhost:27017
								OR
			<var settings = new MongoClientSettings { ReplicaSetName = "rs0" };>
			<var client = new MongoClient(settings);>
		5. **NOTE**: Store mongo client instance in a global place(either as static var or in IoC container with singleton)
			__Note__ Multiple mongo client with same settings, utilize same connection pools underneath
	.
	2. **Monitoring**: utilized ICluster from Mongo.Driver.Core
	3. **Mongo Database**:
		1. IMongoDatabase: to get db use: <var db = client.GetDatabase("dbName");>
		2. If db not exist then create db at first use
		3. IMongoDatabase is thread safe and can be stored globally or in an IoC Container
	4. **Mongo Collection**
		1. IMongoCollection<TDocument> : rep a collection from db. retrieved on IMongoDatabase by GetCollection()
			*__var collection = db.GetCollection<BsonDocument>("collectionName")__*
		2. If Collection not exist: created on first use
		3. TDocument can be any document that can be mapped to and from BSON 

2. __Defination & Builders__
	1. Driver has definations for filters, updates, projections, sorts & index keys. 
	2. Most definations have Builders to aid creation
	3. Every builder has generic param TDocument

	__Feilds__
	4. FieldDefinition<TDocument> and FieldDefinition<TDocument, TField> define how to get a field name
		<a FieldDefinition<BsonDocument> field = "fn";>
		<class Person  // this is for mapped classes
			{
			    [BsonElement("fn")]
			    public string FirstName { get; set; }
			    [BsonElement("ln")]
			    public string LastName { get; set; }
			}>

	__Filters__
	5. FilterDefination<TDocument> defines a filter. you can pass a json string or a Bson Document 
		<a FiltersFilterDefinition<BsonDocument> filter = "{ x: 1 }";
			// or
		<a FilterDefinition<BsonDocument> filter = new BsonDocument("x", 1); a>

	.   __Filter Defination Builder__
		5.1 It can be used to build simple and complex mongo queries. for eg: { x: 10, y: { $lt: 20 } } filter becomes
			<var builder = Builders<BsonDocument>.Filter;
			<var filter = builder.Eq("x", 10) & builder.Lt("y", 20);>
				OR
			<var builder = Builders<Widget>.Filter; >
			<var filter = builder.Eq(widget => widget.X, 10) & builder.Lt(widget => widget.Y, 20);>
			To add multiple builder conditions, & -> and , | -> or

	__Array Operators__
	6. Use methods prefixed with _Any_ to compare the entire array against a single item. 
	   <var filter = Builders<Post>.Filter.AnyEq(x => x.Tags, "mongodb");> : Tags is Array

	__Pipelines__
	7. Define entire aggregation pipeline. 
	   There is no builder for pipeline definations, mostly we use Aggregate Method on IMongoCollection<TDocument>
	   <a PipelineDefinition pipeline = new BsonDocument[] 
		{
		new BsonDocument { { "$match", new BsonDocument("x", 1) } },
		new BsonDocument { { "$sort", new BsonDocument("y", 1) } }
		};>
		__Aggregation Examples__: https://dzone.com/articles/mongodb-aggregation-framework#:~:text=In%20C%23%2C%20the%20pipeline%20is,filter%20out%20the%20given%20documents.

	__Projection__ *https://mongodb.github.io/mongo-csharp-driver/2.1/reference/driver/definitions/*
	var projection = Builders<BsonDocument>.Projection.Include("x").Include("y").Exclude("_id");
		var projection = Builders<Widget>.Projection.Expression(x => new { X = x.X, Y = x.Y }); ]_
		.__Lambda Expression__
			Driver supports expression trees to render projections. 

	__Sorts__
	8. SortDefination<TDocument> : defines how to render a valid document 
		<a SortDefinition<BsonDocument> sort = "{ x: 1 }"; >
		// or
		<a SortDefinition<BsonDocument> sort = new BsonDocument("x", 1); > 
		__Sort Builder__
			SortDefinationBuilder<TDocument>
				<var builder = Builders<Widget>.Sort; >
				<var sort = builder.Ascending(x => x.X).Descending(x => x.Y); >

	__Updates__
	9. UpdateDefination<TDocument> - defines how to render a valid update document. 
		<a UpdateDefinition<BsonDocument> update = "{ $set: { x: 1 } }";
		// or
		<a UpdateDefinition<BsonDocument> update = new BsonDocument("$set", new BsonDocument("x", 1));>
		__Update Defination Builder__
		<a var builder = Builders<Widget>.Update;
		<a var update = builder.Set(widget => widget.X, 1).Set(widget => widget.Y, 3).Inc(widget => widget.Z, 1);

	__Index Keys__

3. __ADMINISTRATION__
	1. Dropping a DB: <a await client.DropDatabaseAsync("dbName")>
	2. Listing the Databases: 
	<a using (var cursor = await client.ListDatabaseAsync())
			{
			    var list = await cursor.ToListAsync();
			    // do something with the list
			} >
	__Collections__

	1. Get : var collection = <a db.GetCollection<BsonDocument>("collectionName");
	2. Create: <a await db.CreateCollectionAsync(
											    "collectionName", 
											    new CreateCollectionOptions
											    {
											        Capped = true,
											        MaxSize = 10000 // max size in bytes
											    });>
	3. Dropping: <a await db.DropCollectionAsync("test");>
	4. List: <a using (var cursor = await db.ListCollectionsAsync())
					{
					    var list = await cursor.ToListAsync();
					    // do something with the list
					}>
	5. Renaming: <a await db.RenameCollectionAsync("oldName", "newName");>
	6. Indexes: IMongoCollection contains Index property which contains all index related operations 

4. __READING & WRITING__
	1. CRUD are defined on IMongoCollectio<TDocument>
	2. Most CRUD API take some form of defination document 
	__Reading__
		1. Counting: counting all document matching a particular passed filter. Pass Empty filter for counting all. 
			<var count = await collection.CountAsync(new BsonDocument("x", 10));
				// or
			var count = await collection.CountAsync(x => x.Age > 20);>
		.
		2. Finding Document: To find all, pass empty filter. Cursor gets automatically disposed once done
			Once you get cursor(IAsyncCursor<TDocument>)
			<var filter = new BsonDocument();
				using (var cursor = await collection.Find(filter).ToCursorAsync())
				{
				    while (await cursor.MoveNextAsync())
				    {
				        foreach (var doc in cursor.Current)
				        {
				            // do something with the documents
				        }
				    }
				}>
			.
			Some options are available through fluent like, sort, skip, limit. 
			Some options can be passed through _FindOptions_
			Order of method is irrelavent like .Skip().limit() is same as .limit().skip()
				 <a var filter = new BsonDocument();
					var options = new FindOptions
					{
					    MaxTime = TimeSpan.FromMilliseconds(20)
					};
					using (var cursor = await collection.Find(filter, options).Skip(10).Limit(20).ToCursorAsync())
					{
					    // etc...
					}>
		.
		3. Iteration: 
			1. ToListAsync is directly avaiable for iteration. 
				IMPORTANT: this is ok when list is small or you need all at once but consider the memory factor
			  	<a var list = await collection.Find(filter)
			    .Skip(10)
			    .ToListAsync();>
		.
			2. ForEachAsync is also available : Use when you need to process each document but not keep them around. 
				<a await collection.Find(filter)
			    .Skip(10)
			    .ForEachAsync(doc => Console.WriteLine(doc)); >
			to avoid blocking while processesing async can be used. 
				<a		await collection.Find(filter)
				.Skip(10)
				.ForEachAsync(async (doc) => await Console.WriteLineAsync(doc));>
			NOTE: Disposing of cursor will be handled automatically 
		.
		4. Single Result:
			1. FirstAync, FirstOrDefaultAsync, SingleAsync, SingleOrDefaultAsync 
			<a await collection.Find(filter)
				    .Skip(10)
				    .ForEachAsync(async (doc) => await Console.WriteLineAsync(doc));>
 .
 	__Aggregation__
	 	1. MongoDb provides Aggregation Framework which provides Aggregate Method. 
	 	2. Result Type: IAggregateFluent which gives access to fluent APIs to build aggregation interface
	 	<a 
	 	[BsonIgnoreExtraElements]
		class ZipEntry
		{
		    [BsonId]
		    public string Zip { get; set; }

		    [BsonElement("city")]
		    public string City { get; set; }

		    [BsonElement("state")]
		    public string State { get; set; }

		    [BsonElement("pop")]
		    public int Population { get; set; }
		}

		var results = await db.GetCollection<ZipEntry>.Aggregate()
		    .Group(x => x.State, g => new { State = g.Key, TotalPopulation = g.Sum(x => x.Population) })
		    .Match(x => x.TotalPopulation > 20000)
		    .ToListAsync();

		 The above is same as: 
		 <a [{ group: { _id: '$state', TotalPopulation: { $sum : '$pop' } } },
		  { $match: { TotalPopulation: { $gt: 20000 } } }] >
		  .

		$project 
			It is avaiable via Project method. It is not executed client side, so it should be fully translatable to server side. 
			Project(x => new { Name = x.FirstName + " " + x.LastName });
		$match:
			Match(x => x.Age > 21); Other overloads of Match method is available
		$redact: 
			No method defined for $redact. It can be added using AppendStage
		$limit:
			Through Limit(20)
		$group:
			Group(x => x.Name, g => new { Name = g.Key, AverageAge = g.Average(x = x.Age) });
		$sort:
			SortBy(x => x.LastName).ThenByDescending(x => x.Age);
		$lookup: https://www.axonize.com/blog/iot-technology/joining-collections-in-mongodb-using-the-c-driver-and-linq/
		

	__LINQ__
		1. Driver contains LINQ implementation that targets aggregation framework. 
		NOTE: Hooking into LINQ requires getting access to IQueryable, for which driver has a method AsQueryable() on IMongoCollection 
			<var collection = db.GetCollection<Person>("people");
			<var queryable = collection.AsQueryable();>
		.		
		var query = from p in collection.AsQueryable()
            where p.Age > 21
            select new { p.Name, p.Age };
		// or, using method syntax
		var query = collection.AsQueryable()
			.Where(p => p.Age > 21)
			.Select(p => new { p.Name, p.Age });
		__NOTE__: Select is used to select value from collection, selectMany is used to select value from nested collections
		2. Supported Stages
			$project: 
				var query = collection.AsQueryable()
    						.Select(p => new { p.Name, p.Age });
    		$match:
    			var query = from p in collection.AsQueryable()
				            where p.Age > 21
				            select p;
			$limit: var query = collection.AsQueryable().Take(10);
			$skip: var query = collection.AsQueryable().Skip(10);
			$unwind: 
				var query = collection.AsQueryable()
    						.SelectMany(p => p.Pets);
    			var query = from p in collection.AsQueryable()
				            from pet in p.Pets
				            select new { Name = pet.Name, Age = p.Age};
				// or
				var query = collection.AsQueryable()
			    			.SelectMany(p => p.Pets, (p, pet) => new { Name = pet.Name, Age = p.Age});
			$group:
				var query = from p in collection.AsQueryable()
				            group p by p.Name into g
				            select new { Name = g.Key, Count = g.Count() };
				var query = collection.AsQueryable()
    	.					GroupBy(p => p.Name, (k, s) => new { Name = k, Count = s.Count()});
    		$sort: using method OrderBy & ThenByAscending or ThenByDescending
    		.
    		2. All forms of Any(), Average(), Count(), LongCOunt(), Distinct()
    		3. ofType(): // assuSumg Customer inherits from Person
							var result = collection.AsQueryable().OfType<Customer>();
		


	__WRITING__:
		1. Insert: InsertOneAsync() & InsertManyAsync(Takes Enumerable of docs to be inserted)
			var doc = new BsonDocument("x", 1);
			await collection.InsertOneAsync(doc);
		2. Update: 3 Methods are available\
			1. ReplaceOneAsync - When you have to update entire document 
			<a var newDoc = new BsonDocument { { "_id", 10 }, { "x", 2 } };
				var result = await collection.ReplaceOneAsync(
			    	filter: new BsonDocument("_id", 10),
			    	replacement: newDoc); >
			2. UpdateOneAsync & UpdateManyAsync - it is used when using update specification 
				var filter = new BsonDocument();
				var update = new BsonDocument("$set", new BsonDocument("x", 1));
				var result = await collection.UpdateOneAsync(filter, update);
				var result = await collection.UpdateManyAsync(filter, update);
			3. Upsert: If we want to upsert, each update method takes optional UpdateOptions
				var filter = new BsonDocument();
				var update = new BsonDocument("$set", new BsonDocument("x", 1));
				var options = new UpdateOptions { IsUpsert = true };
				var result = await collection.UpdateManyAsync(filter, update, options);
		3. Delete: DeleteOneAsync & DeleteManyAsync , it also requires a filter to be passed. 
		4. Find & Modify: It will perform some operation on document then it will return either original or modified document by default it will always return original document only. 
			4. FindOneAndDeleteAsync:
				var filter = new BsonDocument("FirstName", "Jack");
				var result = await collection.FindOneAndDeleteAsync(filter);
				if (result != null)
				{
				    Assert(result["FirstName"] == "Jack");
				}
			4. FindOneAndReplace:
				var filter = new BsonDocument("FirstName", "Jack");
				var replacementDocument = new BsonDocument("FirstName", "John");
				var result = await collection.FindOneAndReplaceAsync(filter, doc);
				if (result != null)
				{
				    Assert(result["FirstName"] == "Jack");
				}
			5. FindOneAndUpdate:
				var filter = new BsonDocument("FirstName", "Jack");
				var update = Builders<BsonDocument>.Update.Set("FirstName", "John");
				var result = await collection.FindOneAndUpdateAsync(filter, update);
				if (result != null)
				{
				    Assert(result["FirstName"] == "Jack");
				}
			6. 
