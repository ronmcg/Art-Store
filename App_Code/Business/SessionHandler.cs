using System;
using System.Collections;
using System.Linq;
using System.Web;

namespace Content.Business
{
    /// <summary>
    /// The users favourites and the users cart are kept as ArrayLists in the session. 
    /// You can get all, add to, and remove from the these sessions.
    /// The sorting sessions are simply a bool, we flip this depending on which way the data is already sorted.
    /// </summary>
    public static class SessionHandler
    {
        
        #region properties

        /// <summary>
        /// Getters and Setters for sort properties of favourites/cart.
        /// </summary>
        public static string Artist
        {
            get { return "ARTIST"; }
        }
        public static string ArtWork
        {
            get { return "ARTWORK"; }
        }
        public static string Cart
        {
            get { return "CART"; }
        }
        public static string SortName
        {
            get { return "SORTED_NAME"; }
        }
        public static string SortTitle
        {
            get { return "SORTED_TITLE"; }
        }
        public static string SortMSRP
        {
            get { return "SORTED_MSRP"; }
        }
        public static string SortYear
        {
            get { return "SORTED_YEAR"; }
        }

        #endregion

        /// <summary>
        /// Returns the array list saved in the session
        /// </summary>
        /// <param name="whichSession">Must use this class' properties Cart, Artist or ArtWork</param>
        /// <returns></returns>
        public static ArrayList GetUsersSession(string whichSession)
        {
            return (ArrayList)HttpContext.Current.Session[whichSession];
        }

        /// <summary>
        /// Add an object to one of the users sessions, faves or cart
        /// </summary>
        /// <param name="whichSession">Must use this class' properties Cart, Artist or ArtWork</param>
        /// <param name="idToAdd">The id of the object to add</param>
        public static void AddToUsersSession(string whichSession, int idToAdd)
        {
            ArrayList faves = (ArrayList)HttpContext.Current.Session[whichSession];
            if (faves == null)
            {
                faves = new ArrayList();
            }
            if (faves.BinarySearch(idToAdd) < 0)
            {
                //Search returns negative on not found
                faves.Add(idToAdd);
                HttpContext.Current.Session[whichSession] = faves;
            }
        }

        /// <summary>
        /// Since we can't know which way the data is sorted we
        /// must use a session to keep a bool indicating whether
        /// it is sorted ascending or not.
        /// Changes the direction of the sort, defaults to false
        /// since the data is already sorted ascending
        /// </summary>
        /// <param name="whichSession">What column we are sorting</param>
        /// <returns>Whether the data is ascending or not</returns>
        public static bool FlipSortingSession(string whichSession)
        {
            if (HttpContext.Current.Session[whichSession] == null)
            {
                HttpContext.Current.Session[whichSession] = false;
            }
            bool isSorted = (bool)HttpContext.Current.Session[whichSession];
            if (isSorted)
            {
                HttpContext.Current.Session[whichSession] = false;
                return false;
            }
            else
            {
                HttpContext.Current.Session[whichSession] = true;
                return true;
            }
        }

        /// <summary>
        /// Removes an object from the users session
        /// </summary>
        /// <param name="whichSession">Must use this class' properties Cart, Artist or ArtWork</param>
        /// <param name="idToDelete">The id of the object to delete</param>
        public static void RemoveFromUsersSession(string whichSession, int idToDelete)
        {
            ArrayList newList = (ArrayList)HttpContext.Current.Session[whichSession];
            int locationToDelete = newList.IndexOf(idToDelete);
            if (locationToDelete >= 0)
            {
                newList.RemoveAt(locationToDelete);
            }
            HttpContext.Current.Session[whichSession] = newList;
        }
    }
}