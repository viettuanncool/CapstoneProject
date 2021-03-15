using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Models
{
    public class ListingRepos : IListingRepos
    {
        public IQueryable<Listing> Listings => throw new NotImplementedException();

        public void AddListing(Listing listing)
        {
            throw new NotImplementedException();
        }

        public void DeleteListing(Listing listing)
        {
            throw new NotImplementedException();
        }

        public void UpdateListing(Listing listing)
        {
            throw new NotImplementedException();
        }
    }
}
