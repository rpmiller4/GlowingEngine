using System;

namespace GlowingEngine
{
    public interface IGetAgeSumIntersect
    {
        DateTime GetAgeSumIntersect(DateTime parent, params DateTime[] children);
    }
}