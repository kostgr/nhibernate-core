﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.Linq;
using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH2257
{
	using System.Threading.Tasks;
	[TestFixture]
	public class FixtureAsync : BugTestCase
	{
		protected override bool AppliesTo(NHibernate.Dialect.Dialect dialect)
		{
			return (dialect is NHibernate.Dialect.InformixDialect1000);
		}

		[Test]
		public async Task InformixUsingDuplicateParametersAsync()
		{
			using (var session = OpenSession())
			using (var transaction = session.BeginTransaction())
			{
				await (session.SaveAsync(new Foo() { Name = "aa" }));

				var list =
					await (session.CreateQuery("from Foo f where f.Name = :p1 and not f.Name <> :p1")
						.SetParameter("p1", "aa")
						.ListAsync<Foo>());

				Assert.That(list.Count, Is.EqualTo(1));
			}
		}
	}
}
