-- Insert Benefits if they don't exist
IF NOT EXISTS (SELECT 1 FROM Benefits WHERE BenefitId = 1)
BEGIN
    SET IDENTITY_INSERT Benefits ON;
    
    INSERT INTO Benefits (BenefitId, BenefitName, BenefitType, ProviderName, MonthlyPremium, IsActive)
    VALUES 
    (1, 'Medicare Supplement Plan F', 'Medical', 'Blue Cross Blue Shield', 185.50, 1),
    (2, 'Medicare Advantage HMO', 'Medical', 'UnitedHealthcare', 0.00, 1),
    (3, 'Dental PPO', 'Dental', 'Delta Dental', 45.00, 1),
    (4, 'Vision Plan', 'Vision', 'VSP', 18.75, 1),
    (5, 'Prescription Drug Plan', 'Pharmacy', 'CVS Caremark', 32.50, 1);
    
    SET IDENTITY_INSERT Benefits OFF;
END

-- Insert Retirees if they don't exist
IF NOT EXISTS (SELECT 1 FROM Retirees WHERE RetireeId = 1)
BEGIN
    SET IDENTITY_INSERT Retirees ON;
    
    INSERT INTO Retirees (RetireeId, FirstName, LastName, DateOfBirth, Email, IsActive, CreatedAt)
    VALUES 
    (1, 'Anurag', 'Varma', '1955-03-15', 'anurag.varma@benistar.com', 1, '2024-01-10'),
    (2, 'Mark', 'Johnson', '1958-07-22', 'mark.johnson@benistar.com', 1, '2024-02-15'),
    (3, 'Robert', 'Williams', '1953-11-08', 'robert.williams@benistar.com', 1, '2024-03-20'),
    (4, 'Patricia', 'Brown', '1960-05-30', 'patricia.brown@benistar.com', 1, '2024-04-05');
    
    SET IDENTITY_INSERT Retirees OFF;
END

-- Insert RetireeBenefits if they don't exist
IF NOT EXISTS (SELECT 1 FROM RetireeBenefits WHERE RetireeBenefitId = 1)
BEGIN
    SET IDENTITY_INSERT RetireeBenefits ON;
    
    INSERT INTO RetireeBenefits (RetireeBenefitId, RetireeId, BenefitId, CoverageStartDate, CoverageEndDate, IsActive, EnrolledAt)
    VALUES 
    (1, 1, 1, '2024-01-01', NULL, 1, '2024-01-10'),
    (2, 1, 3, '2024-01-01', NULL, 1, '2024-01-10'),
    (3, 2, 2, '2024-02-01', NULL, 1, '2024-02-15'),
    (4, 2, 4, '2024-02-01', NULL, 1, '2024-02-15'),
    (5, 3, 1, '2024-03-01', NULL, 1, '2024-03-20'),
    (6, 3, 5, '2024-03-01', NULL, 1, '2024-03-20'),
    (7, 4, 2, '2024-04-01', NULL, 1, '2024-04-05');
    
    SET IDENTITY_INSERT RetireeBenefits OFF;
END
