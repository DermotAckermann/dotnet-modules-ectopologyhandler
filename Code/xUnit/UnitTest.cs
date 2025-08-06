using Xunit.Priority;

namespace AA.Modules.EcTopologyHandler.TestsXUnit;

[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class EcTopologyHandlerTests
{


    static EcTopologyHandlerTests()
    {
        
    }


    [Fact, Priority(1)]
    public void FirstTest()
    {

    }


}


