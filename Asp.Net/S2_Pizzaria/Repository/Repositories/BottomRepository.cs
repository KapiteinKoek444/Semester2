﻿using Repository.DBCon;
using Repository.Entities.Pizza_Components.BottomType;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
	public class BottomRepository
	{
		public PizzariaDB database;

		public BottomRepository(PizzariaDB _database)
		{
			database = _database;
		}

		public Bottom GetBottom(Guid bottomId)
		{
			return database.Bottom.Where(x => x.Id == bottomId).FirstOrDefault();
		}

		public List<Bottom> GetAllBottoms()
		{
			return database.Bottom.ToList();
		}

		public Bottom AddBottom(Bottom bottom)
		{
			database.Bottom.Add(bottom);
			return bottom;
		}

		public Bottom RemoveBottom(Bottom bottom)
		{
			database.Bottom.Remove(bottom);
			return bottom;
		}
	}
}