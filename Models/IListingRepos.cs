using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Models
{
    public interface IListingRepos
    {
        public IQueryable<Listing> Listings { get; }
        public void AddListing(Listing listing);
        public void UpdateListing(Listing listing);
        public void DeleteListing(Listing listing);
    }
}
