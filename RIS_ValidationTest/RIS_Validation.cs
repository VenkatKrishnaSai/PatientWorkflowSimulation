using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RIS_InputValidation;

namespace RIS_ValidationTest
{
    [TestClass]
    public class RIS_Validation
    {
        [TestMethod]
        public void When_ValidInputCharacters_Given_ProceedToModality()
        {
            //RIS_ViewModel ris_ViewModel = new RIS_ViewModel();
           RIS_InputFieldValidation  ris_InputFieldValidation= new RIS_InputFieldValidation();

            string patientFirstName = "Alka";
            string patientMiddleName = "kumari";
            string patientLastName = "choudhary";
            string referringPhysicianName = "Dr Shashi bhushan";
            string performingPhysicianName = "Dr kiran";

            bool expectedResult = true;

            bool actualResult= ris_InputFieldValidation.validation_check(patientFirstName, patientMiddleName, patientLastName, referringPhysicianName, performingPhysicianName);

            Assert.AreEqual(actualResult, expectedResult);

        }



        [TestMethod]
        public void When_InValidInputCharacters_Given_DontProceedToModality()
        {
            // RIS_ViewModel ris_ViewModel = new RIS_ViewModel();
            RIS_InputFieldValidation ris_InputFieldValidation = new RIS_InputFieldValidation();
            string patientFirstName = "Alka<<";
            string patientMiddleName = "kumari";
            string patientLastName = "choudhary";
            string referringPhysicianName = "Dr Shashi bhushan";
            string performingPhysicianName = "Dr kiran";

            bool expectedResult = false;

            bool actualResult = ris_InputFieldValidation.validation_check(patientFirstName, patientMiddleName, patientLastName, referringPhysicianName, performingPhysicianName);

            Assert.AreEqual(actualResult, expectedResult);

        }
    }
}
