using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;

namespace InstrumentsFramework;

public class InstrumentsFrameworkModSystem : ModSystem
{
    private ICoreAPI? mApi;
    
    public override void Start(ICoreAPI api)
    {
        mApi = api;
    }
}
