﻿namespace PatientService.Model
{
    public class PatientRegisteredEvent
    {
        public string PatientId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
