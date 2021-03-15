using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Models
{
    public class ListingRepos : IListingRepos
    {
        public IQueryable<Listing> Listings => throw new NotImplementedException();
        DbContextDao context = new();

        public void AddListing(Listing listing)
        {
            context.Listings.Add(listing);
            context.SaveChanges();
        }

        public void DeleteListing(Listing listing)
        {
            context.Listings.Remove(listing);
            context.SaveChanges();
        }

        public void UpdateListing(Listing listing)
        {
            context.Listings.Update(listing);
            context.SaveChanges();
        }
    }
}
