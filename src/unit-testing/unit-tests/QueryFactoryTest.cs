﻿// The following code was generated by Microsoft Visual Studio 2005.
// The test owner should check each test for validity.
using System;
using LinqToRdf;
using LinqToRdf.Sparql;
using NUnit.Framework;
using RdfMusic;
using SemWeb;
using UnitTests.Properties;
using Rhino.Mocks;
using UnitTests.TaskEntityModel; 

namespace UnitTests
{
	/// <summary>
	///This is ontology test class for LinqToRdf.QueryFactory&lt;T&gt; and is intended
	///to contain all LinqToRdf.QueryFactory&lt;T&gt; Unit Tests
	///</summary>
	[TestFixture]
	public class QueryFactoryTest
	{
		#region helpers

		private static Store CreateMemoryStore()
		{
			Store result = new MemoryStore();
			string serialisedLocation = Settings.Default.testStoreLocation;
			result.Import(new N3Reader(serialisedLocation));
			return result;
		}

		private static TripleStore CreateInMemoryTripleStore()
		{
            return new TripleStore(CreateMemoryStore(), QueryType.LocalN3StoreInMemory);
		}

		private static TripleStore CreatePersistentTripleStore()
		{
            return new TripleStore(@"some dummy connection string", QueryType.LocalN3StorePersistent);
		}

		private static TripleStore CreateInMemorySparqlTripleStore()
		{
            return new TripleStore(CreateMemoryStore(), QueryType.LocalSparqlStore);
		}

		private static TripleStore CreateOnlineSparqlTripleStore()
		{
			return new TripleStore(@"http://localhost/linqtordf/SparqlQuery.asp");
		}

		#endregion

		#region CreateConnection

		/// <summary>
		///A test for CreateConnection (IRdfQuery&lt;T&gt;)
		///</summary>
		[Test]
		public void CreateConnectionTest_InMemorySparqlTripleStore()
		{
			TestConnectionCreationForTripleStore(CreateInMemorySparqlTripleStore());
		}

		/// <summary>
		///A test for CreateConnection (IRdfQuery&lt;T&gt;)
		///</summary>
		[Test]
		public void CreateConnectionTest_OnlineSparqlTripleStore()
		{
			TestConnectionCreationForTripleStore(CreateOnlineSparqlTripleStore());
		}

		/// <summary>
		///A test for CreateConnection (IRdfQuery&lt;T&gt;)
		///</summary>
		[Test]
		[ExpectedException(typeof(ApplicationException))]
		public void CreateConnectionTest_InMemoryTripleStore()
		{
			TestConnectionCreationForTripleStore(CreateInMemoryTripleStore());
		}

		/// <summary>
		///A test for CreateConnection (IRdfQuery&lt;T&gt;)
		///</summary>
		[Test]
		[ExpectedException(typeof(ApplicationException))]
		public void CreateConnectionTest_PersistentTripleStore()
		{
			TestConnectionCreationForTripleStore(CreatePersistentTripleStore());
		}

		private static void TestConnectionCreationForTripleStore(TripleStore ts1)
		{
			IRdfContext context = new RdfDataContext(ts1);
			QueryFactory<Track> factory = new QueryFactory<Track>(ts1.QueryType, context);
			IRdfQuery<Track> qry1 = context.ForType<Track>();
			IRdfConnection<Track> rdfConnection = factory.CreateConnection(qry1);
			Assert.IsNotNull(rdfConnection);
		}

		#endregion

		#region CreateExpressionTranslator

		/// <summary>
		///A test for CreateExpressionTranslator ()
		///</summary>
		[Test]
		public void CreateExpressionTranslatorTest()
		{
			TripleStore ts = CreateOnlineSparqlTripleStore();
			IRdfContext context = new RdfDataContext(ts);
			QueryFactory<Track> factory = new QueryFactory<Track>(ts.QueryType, context);
			Assert.AreEqual(factory.QueryType, ts.QueryType);
			IQueryFormatTranslator translator = factory.CreateExpressionTranslator();
			Assert.IsNotNull(translator);
            Assert.IsTrue(translator is LinqToSparqlExpTranslator<Track>);
		}

		/// <summary>
		///A test for CreateExpressionTranslator ()
		///</summary>
		[Test]
		public void CreateExpressionTranslatorTest2()
		{
			TripleStore ts = CreateInMemoryTripleStore();
			IRdfContext context = new RdfDataContext(ts);
			QueryFactory<Track> factory = new QueryFactory<Track>(ts.QueryType, context);
			Assert.AreEqual(factory.QueryType, ts.QueryType);
			IQueryFormatTranslator translator = factory.CreateExpressionTranslator();
			Assert.IsNotNull(translator);
			Assert.IsTrue(translator is LinqToN3ExpTranslator<Track>);
		}

		#endregion

		#region CreateQuery

		/// <summary>
		///A test for CreateQuery&lt;&gt; ()
		///</summary>
		[Test]
		public void CreateQueryTest_OnlineSparqlTripleStore()
		{
			TripleStore ts = CreateOnlineSparqlTripleStore();
			IRdfContext context = new RdfDataContext(ts);
			QueryFactory<Track> factory = new QueryFactory<Track>(ts.QueryType, context);
			Assert.AreEqual(factory.QueryType, ts.QueryType);
			IRdfQuery<Track> query = factory.CreateQuery<Track>();
			Assert.IsNotNull(query);
            Assert.IsTrue(query is SparqlQuery<Track>);
		}

		/// <summary>
		///A test for CreateQuery&lt;&gt; ()
		///</summary>
		[Test]
		public void CreateQueryTest_InMemorySparqlTripleStore()
		{
			TripleStore ts = CreateInMemorySparqlTripleStore();
			IRdfContext context = new RdfDataContext(ts);
			QueryFactory<Track> factory = new QueryFactory<Track>(ts.QueryType, context);
			Assert.AreEqual(factory.QueryType, ts.QueryType);
			IRdfQuery<Track> query = factory.CreateQuery<Track>();
			Assert.IsNotNull(query);
            Assert.IsTrue(query is SparqlQuery<Track>);
        }

		/// <summary>
		///A test for CreateQuery&lt;&gt; ()
		///</summary>
		[Test]
		public void CreateQueryTest_InMemoryTripleStore()
		{
			TripleStore ts = CreateInMemoryTripleStore();
			IRdfContext context = new RdfDataContext(ts);
			QueryFactory<Track> factory = new QueryFactory<Track>(ts.QueryType, context);
			Assert.AreEqual(factory.QueryType, ts.QueryType);
			IRdfQuery<Track> query = factory.CreateQuery<Track>();
			Assert.IsNotNull(query);
            Assert.IsTrue(query is RdfN3Query<Track>);
        }

		/// <summary>
		///A test for CreateQuery&lt;&gt; ()
		///</summary>
		[Test]
		public void CreateQueryTest_PersistentTripleStore()
		{
			TripleStore ts = CreatePersistentTripleStore();
			IRdfContext context = new RdfDataContext(ts);
			QueryFactory<Track> factory = new QueryFactory<Track>(ts.QueryType, context);
			Assert.AreEqual(factory.QueryType, ts.QueryType);
			IRdfQuery<Track> query = factory.CreateQuery<Track>();
			Assert.IsNotNull(query);
            Assert.IsTrue(query is RdfN3Query<Track>);
        }

		#endregion
		protected MockRepository mocks;
		/// <summary>
		///A test for QueryFactory (QueryType, IRdfContext)
		///</summary>
		[Test]
		public void ConstructorTest()
		{
			mocks = new MockRepository();
			TripleStore ts = mocks.CreateMock<TripleStore>("http://www.tempuri.com");
			IRdfContext context = mocks.CreateMock<RdfDataContext>(ts);
			QueryFactory<Track> factory = new QueryFactory<Track>(ts.QueryType, context);
			Assert.IsNotNull(factory); 
		}

		/// <summary>
		///A test for QueryType
		///</summary>
        [Test]
		public void QueryTypeTest()
		{
			mocks = new MockRepository();
			QueryType queryType = QueryType.RemoteSparqlStore; // TODO: Initialize to an appropriate value
			TripleStore ts = new TripleStore("http://www.tempuri.com");
			IRdfContext context = mocks.CreateMock<RdfDataContext>(ts);
			QueryFactory<Task> target = new QueryFactory<Task>(queryType, context);
			QueryType val = QueryType.RemoteSparqlStore; // TODO: Assign to an appropriate value for the property
			Assert.AreEqual(val, target.QueryType, "LinqToRdf.QueryFactory<T>.QueryType was not set correctly.");
//			Assert.Fail("Generics testing must be manually provided.");
		}
	}
}
