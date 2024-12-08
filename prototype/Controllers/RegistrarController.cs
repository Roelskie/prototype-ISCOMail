    using Microsoft.AspNetCore.Mvc;
    using prototype.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    using prototype.Models.Register;  // For User and PersonalInformation
    using prototype.Models.Student;   // For StudentEnlistment and others
    using prototype.Models.Registrar;
    using prototype.Models;           // For StudentEnlistment and others

    namespace prototype.Controllers
    {
    public class RegistrarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistrarController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult ViewProfiles(string studentId)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return RedirectToAction("Index");
            }

            var studentDetails = (from user in _context.Users
                                  join BasicInformation in _context.BASIC_INFORMATION
                                  on user.ACC_STUDENT_ID equals BasicInformation.BI_STUDENT_ACC_ID
                                  join personal in _context.PERSONAL_INFORMATION
                                  on user.ACC_STUDENT_ID equals personal.P_STUDENT_ACC_ID
                                  join Educations in _context.EDUCATION
                                  on user.ACC_STUDENT_ID equals Educations.E_STUDENT_ACC_ID
                                  join Family in _context.FAMILY
                                  on user.ACC_STUDENT_ID equals Family.F_STUDENT_ACC_ID
                                  join EmergencyContact in _context.PERSON_INCASEOF_EMERGENCY
                                  on user.ACC_STUDENT_ID equals EmergencyContact.PICOE_STUDENT_ACC_ID
                                  join enlistment in _context.STUDENT_ENLISTMENT
                                  on user.ACC_STUDENT_ID equals enlistment.SEF_STUDENT_ACC_ID
                                  join screening in _context.StudentYrScreenings
                                  on user.ACC_STUDENT_ID equals screening.SYC_STUDENT_ACC_ID
                                  join grading in _context.StudentGradings
                                  on user.ACC_STUDENT_ID equals grading.GRADES_STUDENT_ID
                                  where user.ACC_STUDENT_ID == studentId
                                  select new StudentDetailsViewModel
                                  {
                                      // PersonalInformation /// 
                                      FirstName = personal.FIRST_NAME,
                                      MiddleName = personal.MIDDLE_NAME,
                                      LastName = personal.LAST_NAME,
                                      Suffix = personal.SUFFIX,
                                      BirthDate = personal.DATE_OF_BIRTH,
                                      BirthPlace = personal.BIRTH_PLACE,
                                      Citizenship = personal.CITIZENSHIP,
                                      Gender = personal.GENDER,
                                      Religion = personal.RELIGION,
                                      CivilStatus = personal.CIVIL_STATUS,
                                      Barangay = personal.BARANGAY,
                                      District = personal.DISTRICT,
                                      Municipality = personal.MUNICIPALITY,
                                      Street = personal.STREET,
                                      ZipCode = personal.ZIPCODE,

                                      // UserInformation /// 
                                      StudentId = user.ACC_STUDENT_ID,

                                      // BasicInformation /// 
                                      Lrn = BasicInformation.LRN,
                                      ApplyingAs = BasicInformation.APPLYING_AS,
                                      Application_DATE = BasicInformation.APPLICATION_DATE,

                                      // Education /// 

                                      CollegeName = Educations.COLLEGE_NAME,
                                      CollegeAddress = Educations.C_ADDRESS,
                                      CollegeCourseYr = Educations.C_COURSE_YR,
                                      CollegeDateGraduated = Educations.C_DATE_GRADUATED,
                                      CollegeHonorsReceived = Educations.C_HONORS_RECEIVED,
                                      CollegeLocation = Educations.C_LOCATION,
                                      CollegeSchoolType = Educations.C_SCHOOL_TYPE,

                                      // Family /// 

                                      FatherFirstName = Family.FATHER_FIRST_NAME,
                                      FatherMiddleName = Family.FATHER_MIDDLE_NAME,
                                      FatherLastName = Family.FATHER_LAST_NAME,
                                      FatherSuffix = Family.FATHER_SUFFIX,
                                      FatherOccupation = Family.FATHER_OCCUPATION,
                                      FatherEducationalAttainment = Family.FATHER_EDUCATIONAL_ATTAINMENT,
                                      FatherContactNumber = Family.FATHER_CONTACT_NUMBER,

                                      MotherFirstName = Family.MOTHER_FIRST_NAME,
                                      MotherMiddleName = Family.MOTHER_MIDDLE_NAME,
                                      MotherLastName = Family.MOTHER_LAST_NAME,
                                      MotherContactNumber = Family.MOTHER_CONTACT_NUMBER,
                                      MotherEducationalAttainment = Family.MOTHER_EDUCATIONAL_ATTAINMENT,
                                      MotherOccupation = Family.MOTHER_OCCUPATION,

                                      FamilyBarangay = Family.FAMILY_BARANGAY,
                                      FamilyDistrict = Family.FAMILY_DISTRICT,
                                      FamilyMunicipality = Family.FAMILY_MUNICIPALITY,
                                      FamilyStreet = Family.FAMILY_STREET,
                                      FamilyZipCode = Family.FAMILY_ZIPCODE,

                                      GuardianFirstName = Family.GUARDIAN_FIRST_NAME,
                                      GuardianMiddleName = Family.GUARDIAN_MIDDLE_NAME,
                                      GuardianLastName = Family.GUARDIAN_LAST_NAME,
                                      GuardianSuffix = Family.GUARDIAN_SUFFIX,
                                      GuardianContactNumber = Family.GUARDIAN_SUFFIX,
                                      GuardianRelationship = Family.GUARDIAN_RELATIONSHIP,


                                      PicoeFirstName = EmergencyContact.PICOE_FIRSTNAME,
                                      PicoeMiddleName = EmergencyContact.PICOE_MIDDLENAME,
                                      PicoeLastName = EmergencyContact.PICOE_LASTNAME,
                                      PicoeSuffix = EmergencyContact.PICOE_SUFFIX,
                                      PicoeContactNumber = EmergencyContact.PICOE_CONTACTNUMBER,
                                      PicoeHouseStreet = EmergencyContact.PICOE_HOUSESTREET,
                                      PicoeBrgy = EmergencyContact.PICOE_BRGY,
                                      PicoeDistrict = EmergencyContact.PICOE_DISTRICT,
                                      PicoeMunicipality = EmergencyContact.PICOE_MUNICIPALITY,
                                      PicoeZipCode = EmergencyContact.PICOE_ZIPCODE,
                                      PicoeRelationship = EmergencyContact.PICOE_RELATIONSHIP,

                                      // StudentScreening /// 
                                      YearLevel = screening.YR_LEVEL,
                                      Term = screening.YR_TERM,
                                      Academic_FROM = screening.ACADEMIC_FROM,
                                      Academic_TO = screening.ACADEMIC_TO,



                                      // StudentReference /// 
                                      ReferenceNumber = _context.StudentReferences
                        .FirstOrDefault(r => r.SR_STUDENT_ACC_ID == studentId).REFERENCE_NUMBER,

                                      // StudentEnlistment /// 
                                      PhotoUrl = enlistment.SEF_ID_PICTURE != null && enlistment.SEF_ID_PICTURE.Length > 0
                        ? $"data:image/jpeg;base64,{Convert.ToBase64String(enlistment.SEF_ID_PICTURE)}"
                        : "/images/default-profile.jpg"
                                  }).FirstOrDefault();


            if (studentDetails == null)
            {
                return NotFound("Student details not found.");
            }

            return View(studentDetails);
        }

        // POST: Save the edited student data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ViewProfiles(string studentId, StudentDetailsViewModel model)

        {
            if (studentId != model.StudentId)
            {
                return BadRequest("Student ID mismatch.");
            }

            if (ModelState.IsValid)
            {
                var student = await _context.Users
                    .FirstOrDefaultAsync(u => u.ACC_STUDENT_ID == studentId);

                if (student != null)
                {
                    // Update the student's personal information
                    var personalInfo = await _context.PERSONAL_INFORMATION
                        .FirstOrDefaultAsync(p => p.P_STUDENT_ACC_ID == studentId);

                    if (personalInfo != null)
                    {
                        personalInfo.FIRST_NAME = model.FirstName;
                        personalInfo.MIDDLE_NAME = model.MiddleName;
                        personalInfo.LAST_NAME = model.LastName;
                        personalInfo.SUFFIX = model.Suffix;
                        personalInfo.DATE_OF_BIRTH = model.BirthDate;
                        personalInfo.BIRTH_PLACE = model.BirthPlace;
                        personalInfo.CITIZENSHIP = model.Citizenship;
                        personalInfo.GENDER = model.Gender;
                        personalInfo.RELIGION = model.Religion;
                        personalInfo.CIVIL_STATUS = model.CivilStatus;
                        personalInfo.BARANGAY = model.Barangay;
                        personalInfo.DISTRICT = model.District;
                        personalInfo.MUNICIPALITY = model.Municipality;
                        personalInfo.STREET = model.Street;
                        personalInfo.ZIPCODE = model.ZipCode;
                    }

                    // Update Education
                    var education = await _context.EDUCATION
                        .FirstOrDefaultAsync(e => e.E_STUDENT_ACC_ID == studentId);
                    if (education != null)
                    {
                        education.COLLEGE_NAME = model.CollegeName;
                        education.C_ADDRESS = model.CollegeAddress;
                        education.C_COURSE_YR = model.CollegeCourseYr;
                        education.C_DATE_GRADUATED = model.CollegeDateGraduated;
                        education.C_HONORS_RECEIVED = model.CollegeHonorsReceived;
                        education.C_LOCATION = model.CollegeLocation;
                        education.C_SCHOOL_TYPE = model.CollegeSchoolType;
                    }

                    // Update Family Information
                    var family = await _context.FAMILY
                        .FirstOrDefaultAsync(f => f.F_STUDENT_ACC_ID == studentId);
                    if (family != null)
                    {
                        family.FATHER_FIRST_NAME = model.FatherFirstName;
                        family.FATHER_MIDDLE_NAME = model.FatherMiddleName;
                        family.FATHER_LAST_NAME = model.FatherLastName;
                        family.FATHER_SUFFIX = model.FatherSuffix;
                        family.FATHER_OCCUPATION = model.FatherOccupation;
                        family.FATHER_EDUCATIONAL_ATTAINMENT = model.FatherEducationalAttainment;
                        family.FATHER_CONTACT_NUMBER = model.FatherContactNumber;
                        // Similarly for Mother and Guardian
                        family.MOTHER_FIRST_NAME = model.MotherFirstName;
                        family.MOTHER_MIDDLE_NAME = model.MotherMiddleName;
                        family.MOTHER_LAST_NAME = model.MotherLastName;
                        family.MOTHER_CONTACT_NUMBER = model.MotherContactNumber;
                        family.MOTHER_EDUCATIONAL_ATTAINMENT = model.MotherEducationalAttainment;
                        family.MOTHER_OCCUPATION = model.MotherOccupation;

                        // Update Family Address
                        family.FAMILY_BARANGAY = model.FamilyBarangay;
                        family.FAMILY_DISTRICT = model.FamilyDistrict;
                        family.FAMILY_MUNICIPALITY = model.FamilyMunicipality;
                        family.FAMILY_STREET = model.FamilyStreet;
                        family.FAMILY_ZIPCODE = model.FamilyZipCode;

                        family.GUARDIAN_FIRST_NAME = model.GuardianFirstName;
                        family.GUARDIAN_MIDDLE_NAME = model.GuardianMiddleName;
                        family.GUARDIAN_LAST_NAME = model.GuardianLastName;
                        family.GUARDIAN_SUFFIX = model.GuardianSuffix;
                        family.GUARDIAN_CONTACT_NUMBER = model.GuardianContactNumber;
                        family.GUARDIAN_RELATIONSHIP = model.GuardianRelationship;
                    }

                    // Update Emergency Contact Information
                    var emergencyContact = await _context.PERSON_INCASEOF_EMERGENCY
                        .FirstOrDefaultAsync(e => e.PICOE_STUDENT_ACC_ID == studentId);
                    if (emergencyContact != null)
                    {
                        emergencyContact.PICOE_FIRSTNAME = model.PicoeFirstName;
                        emergencyContact.PICOE_MIDDLENAME = model.PicoeMiddleName;
                        emergencyContact.PICOE_LASTNAME = model.PicoeLastName;
                        emergencyContact.PICOE_SUFFIX = model.PicoeSuffix;
                        emergencyContact.PICOE_CONTACTNUMBER = model.PicoeContactNumber;
                        emergencyContact.PICOE_HOUSESTREET = model.PicoeHouseStreet;
                        emergencyContact.PICOE_BRGY = model.PicoeBrgy;
                        emergencyContact.PICOE_DISTRICT = model.PicoeDistrict;
                        emergencyContact.PICOE_MUNICIPALITY = model.PicoeMunicipality;
                        emergencyContact.PICOE_ZIPCODE = model.PicoeZipCode;
                        emergencyContact.PICOE_RELATIONSHIP = model.PicoeRelationship;
                    }
                    await _context.SaveChangesAsync();

                    return RedirectToAction("ViewProfiles", new { studentId = studentId });
                }
            }

            return View(model);
        }

        public async Task<ActionResult> Enlist(string studentId)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                TempData["ErrorMessage"] = "Student ID is required to enlist.";
                return RedirectToAction("Index");
            }

            var studentDetails = await (from user in _context.Users
                                        join personal in _context.PERSONAL_INFORMATION
                                        on user.ACC_STUDENT_ID equals personal.P_STUDENT_ACC_ID
                                        join screening in _context.StudentYrScreenings
                                        on user.ACC_STUDENT_ID equals screening.SYC_STUDENT_ACC_ID
                                        join enlistment in _context.STUDENT_ENLISTMENT
                                        on user.ACC_STUDENT_ID equals enlistment.SEF_STUDENT_ACC_ID
                                        where user.ACC_STUDENT_ID == studentId
                                        select new StudentDetailsViewModel
                                        {
                                            StudentId = user.ACC_STUDENT_ID,
                                            FirstName = personal.FIRST_NAME,
                                            MiddleName = personal.MIDDLE_NAME,
                                            LastName = personal.LAST_NAME,
                                            Suffix = personal.SUFFIX,
                                            YearLevel = screening.YR_LEVEL,
                                            Term = screening.YR_TERM,
                                            PhotoUrl = enlistment.SEF_ID_PICTURE != null && enlistment.SEF_ID_PICTURE.Length > 0
                                                ? $"data:image/jpeg;base64,{Convert.ToBase64String(enlistment.SEF_ID_PICTURE)}"
                                                : "/images/default-profile.jpg"
                                        }).FirstOrDefaultAsync();

            if (studentDetails == null)
            {
                TempData["ErrorMessage"] = "No student found with the provided ID.";
                return RedirectToAction("Index");
            }

            // Set ViewBag values
            ViewBag.StudentDetails = studentDetails;
            ViewBag.YearLevel = studentDetails.YearLevel;
            ViewBag.Term = studentDetails.Term;

            var formattedYearLevelTerm = $"{studentDetails.YearLevel}st Year, {studentDetails.Term}st Semester";
            ViewBag.FormattedYearLevelTerm = formattedYearLevelTerm;

            string yearTerm = $"{ViewBag.YearLevel},{ViewBag.Term}";

            // Retrieve schedules based on the Year and Term
            var schedules = _context.SCHEDULE
                                    .Where(s => s.YearSem == yearTerm)
                                    .ToList();

            ViewBag.Schedule = schedules; // Make sure schedules are set correctly

            return View(studentDetails);
        }
        public async Task<IActionResult> GetSections(int yearLevel, int term)
        {
            if (yearLevel == 0 || term == 0)
            {
                return Json(new { error = "Please select Year and Term." });
            }

            string yearSem = $"{yearLevel},{term}";

            var sections = await _context.Sections
                .Where(s => s.SECTION_YEAR_SEM == yearSem)
                .Select(s => s.SECTION_NAME)
                .Distinct()
                .ToListAsync();

            return Json(sections);
        }


        public async Task<IActionResult> GetSchedule(int yearLevel, int term, string section)
        {
            if (yearLevel == 0 || term == 0 || string.IsNullOrEmpty(section))
            {
                return Json(new { error = "Please select Year, Term, and Section." });
            }

            string yearSem = $"{yearLevel},{term}";

            var schedule = await _context.SCHEDULE
                .Where(s => s.YearSem == yearSem && s.Section == section)
                .Select(s => new
                {
                    s.SubjectCode,
                    s.SubjectName,
                    s.Day,
                    s.Time,
                    s.Room,
                    s.Building
                })
                .ToListAsync();

            return Json(schedule);
        }


        // Index Action - List of Students (or any default page)
        public async Task<IActionResult> Index()
        {
            // Fetch students who have a record in the StudentReferences table
            var studentsWithReference = await (from user in _context.Users
                                               join personal in _context.PERSONAL_INFORMATION
                                               on user.ACC_STUDENT_ID equals personal.P_STUDENT_ACC_ID
                                               join enlistment in _context.STUDENT_ENLISTMENT
                                               on user.ACC_STUDENT_ID equals enlistment.SEF_STUDENT_ACC_ID
                                               join screening in _context.StudentYrScreenings
                                               on user.ACC_STUDENT_ID equals screening.SYC_STUDENT_ACC_ID
                                               join grading in _context.StudentGradings
                                               on user.ACC_STUDENT_ID equals grading.GRADES_STUDENT_ID
                                               join reference in _context.StudentReferences // Join with StudentReferences to get Reference Number
                                               on user.ACC_STUDENT_ID equals reference.SR_STUDENT_ACC_ID
                                               where reference.SR_STUDENT_ACC_ID != null // Ensure that the student has a reference record
                                               select new
                                               {
                                                   user.ACC_STUDENT_ID,
                                                   personal.FIRST_NAME,
                                                   personal.MIDDLE_NAME,
                                                   personal.LAST_NAME,
                                                   user.EMAIL,
                                                   enlistment.SEF_ID_PICTURE,
                                                   screening.YR_LEVEL,
                                                   screening.YR_TERM,  // Get YR_TERM
                                                   Gwa = grading.GWA,  // Get GWA from StudentGradings
                                                   ReferenceNumber = reference.REFERENCE_NUMBER // Get REFERENCE_NUMBER from StudentReferences
                                               })
                                                .GroupBy(x => x.ACC_STUDENT_ID) // Group by StudentId to ensure only one row per student
                                                .Select(g => g.FirstOrDefault()) // Take the first record from each group
                                                .ToListAsync();

            // Map the result to StudentProfileViewModel
            var studentProfiles = studentsWithReference.Select(student => new StudentProfileViewModel
            {
                PhotoUrl = student.SEF_ID_PICTURE != null && student.SEF_ID_PICTURE.Length > 0
                           ? Convert.ToBase64String(student.SEF_ID_PICTURE)
                           : string.Empty,
                FullName = $"{student.FIRST_NAME} {student.MIDDLE_NAME} {student.LAST_NAME}",
                Email = student.EMAIL,
                StudentId = student.ACC_STUDENT_ID,
                YearLevelTerm = FormatYearLevelTerm(student.YR_LEVEL, student.YR_TERM), // Format the Year Level and Term
                Gwa = student.Gwa, // Include GWA from StudentGradings
                ReferenceNumber = student.ReferenceNumber // Include Reference Number
            }).ToList();

            // Return the data to the view
            return View(studentProfiles);
        }


        // AddCourse Action - Display Add Course page
        public IActionResult AddCourse()
        {
            return View();
        }


        // Printing Action - Display Printing page
        public IActionResult Printing()
        {
            return View();
        }

        // UpdateCourse Action - Display Update Course page
        public IActionResult UpdateCourse()
        {
            return View();
        }
    
    public IActionResult Section()
        {
            return View();
        }

        // DELETE: /Registrar/DeleteReferenceByStudentId    
        [HttpDelete]
        public async Task<IActionResult> DeleteReferenceByStudentId(string studentId)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return BadRequest("Invalid student ID.");
            }

            var reference = await _context.StudentReferences.FirstOrDefaultAsync(r => r.SR_STUDENT_ACC_ID == studentId);
            if (reference == null)
            {
                return NotFound("Reference for the student not found.");
            }

            try
            {
                _context.StudentReferences.Remove(reference);
                await _context.SaveChangesAsync();
                return Ok("Reference deleted successfully.");
            }
            catch
            {
                return StatusCode(500, "An error occurred while deleting the reference.");
            }
        }




        // Helper method to format YearLevel and Term
        private string FormatYearLevelTerm(string yrLevel, string yrTerm)
        {
            if (string.IsNullOrEmpty(yrLevel) || string.IsNullOrEmpty(yrTerm))
            {
                return "Year and Term data missing";
            }

            // Format Year Level with suffix (st, nd, rd, th)
            string yearSuffix = GetYearSuffix(yrLevel);
            string formattedYrLevel = $"{yrLevel}{yearSuffix} Year";

            // Format YR_TERM (e.g., 1st Semester, 2nd Semester)
            string formattedYrTerm = $"{yrTerm}{GetSemesterSuffix(yrTerm)} Semester";

            // Combine Year Level and Term
            return $"{formattedYrLevel} - {formattedYrTerm}";
        }

        // Helper method to get the suffix for Year Level (st, nd, rd, th)
        private string GetYearSuffix(string yrLevel)
        {
            if (int.TryParse(yrLevel, out int level))
            {
                if (level == 1) return "st";
                else if (level == 2) return "nd";
                else if (level == 3) return "rd";
                else return "th";
            }
            return "th"; // Default to "th" if not a number
        }

        // Helper method to get the suffix for Semester (st, nd)
        private string GetSemesterSuffix(string yrTerm)
        {
            if (int.TryParse(yrTerm, out int term))
            {
                if (term == 1) return "st";
                else if (term == 2) return "nd";
            }
            return ""; // Default if not found
        }

    }
}