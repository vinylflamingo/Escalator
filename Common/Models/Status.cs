namespace Escalator.Common.Models
{
    public enum Status
    {

        //closed enum automatically sets mark complete flag to true.
        submitted, //not sure if should keep submitted or use open as default.
        open,
        closed,
        moreinfo
    }
}