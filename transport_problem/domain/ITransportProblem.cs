using System;
using transport_problem.model;

namespace transport_problem.domain
{
    public interface ITransportProblem
    {
        int[][] calculate(ProblemTable problemTable);
    }
}
