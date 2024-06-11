namespace MyApp.Core.DTO;

public class FeatureFlagsDto
{
    public FeatureFlagsDto(bool dashboardFeatureFlag, bool financeFeatureFlag, bool managementFeatureFlag)
    {
        DashboardFeatureFlag = dashboardFeatureFlag;
        FinanceFeatureFlag = financeFeatureFlag;
        ManagementFeatureFlag = managementFeatureFlag;
    }

    public bool DashboardFeatureFlag { get; private set; }
    public bool FinanceFeatureFlag { get; private set; }
    public bool ManagementFeatureFlag { get; private set; }
}