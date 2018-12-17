﻿using System;
using System.Linq;

namespace IntroToOrms
{
  class Program
  {
    static void Main(string[] args)
    {
      var db = new SafariVacationContext();
      //CREATE Data

      // db.SeenAnimals.Add(new SeenAnimals
      // {
      //   Species = "Lions",
      //   CountOfTimesSeen = 10,
      //   LocationOfLastSeen = "Dessert",
      // });

      // db.SaveChanges();

      // db.SeenAnimals.Add(new SeenAnimals
      // {
      //   Species = "Tigers",
      //   CountOfTimesSeen = 15,
      //   LocationOfLastSeen = "Jungle",
      // });

      // db.SaveChanges();

      //READ Data
      //Display all animals
      var allSeenAnimals = db.SeenAnimals;

      foreach (var seenanimal in allSeenAnimals)
      {
        System.Console.WriteLine(seenanimal.Species);
      }
      //Display animals only seen in the jungle
      var onlySeenInTheJungle = db.SeenAnimals.Where(seenanimal => seenanimal.LocationOfLastSeen == "Jungle");
      System.Console.WriteLine("Animals seen in the Jungle");
      foreach (var seenanimal in onlySeenInTheJungle)
      {
        System.Console.WriteLine(seenanimal.Species);
      }

      //UPDATE Data
      // Update the CountOfTimesSeen and LocationOfLastSeen for an animal
      //Find the objects
      var Tigers = db.SeenAnimals.FirstOrDefault(seenanimal => seenanimal.Id == 3);
      if (Tigers != null)
      {
        //Update the data
        Tigers.CountOfTimesSeen = 30;
        Tigers.LocationOfLastSeen = "Dessert";

        // Save the changes
        db.SaveChanges();
      }

      var Lions = db.SeenAnimals.FirstOrDefault(seenanimal => seenanimal.Id == 1);
      if (Lions != null)
      {
        Lions.LocationOfLastSeen = "Jungle";
        db.SaveChanges();
      }

      var allanimals = db.SeenAnimals;
      foreach (var animals in allanimals)
      {
        Console.WriteLine($"{animals.Id}, {animals.Species}");
      }
      //DELETE Data

    }
  }
}
// var results = db.SeenAnimals.Select(seenanimal => new { seenanimal.CountOfTimesSeen, seenanimal.LocationOfLastSeen });
