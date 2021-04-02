using System;

namespace GlowingEngine
{
    public interface IGetAgeSumIntersect
    {
        public DateTime GetAgeSumIntersect(DateTime parent, params DateTime[] children);
    }
}