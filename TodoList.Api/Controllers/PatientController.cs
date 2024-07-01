using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Entities;
using TodoList.Api.Repositories;
using TodoList.Models;
using TodoList.Models.Enums;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientRepository.GetPatientsList();
            return Ok(patients);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PatientRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var patient = await _patientRepository.Create(new Entities.Patient()
            {
                PatientId = Guid.NewGuid(),
                Name = request.Name,
                Gender = request.Gender,
                Job = request.Job,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                CreatedDate = DateTime.Now,
            });
            return CreatedAtAction(nameof(GetById), new {id = patient.PatientId}, patient);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PatientUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var patientFromDb = await _patientRepository.GetById(id);
            if (patientFromDb == null) return NotFound("Không tìm thấy bệnh nhân");

            patientFromDb.Name = request.Name;
            patientFromDb.Gender = request.Gender;
            patientFromDb.DateOfBirth = request.DateOfBirth;
            patientFromDb.PhoneNumber = request.PhoneNumber;
            patientFromDb.Address = request.Address;
            var result = await _patientRepository.Update(patientFromDb);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var patient = await _patientRepository.GetById(id);
            if (patient == null) return NotFound("Không tìm thấy bệnh nhân");
            await _patientRepository.Delete(patient);
            return Ok(new PatientRequest()
            {
                PatientId = patient.PatientId,
                Name = patient.Name,
                Gender = patient.Gender,
                DateOfBirth = patient.DateOfBirth,
                PhoneNumber = patient.PhoneNumber,
                Address = patient.Address,
                Job = patient.Job,
                CreatedDate = patient.CreatedDate
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var patient = await _patientRepository.GetById(id);
            if (patient == null) return NotFound("Không tìm thấy bệnh nhân");
            return Ok(new PatientRequest()
            {
                PatientId = patient.PatientId,
                Name = patient.Name,
                Gender = patient.Gender,
                DateOfBirth = patient.DateOfBirth,
                PhoneNumber = patient.PhoneNumber,
                Address = patient.Address,
                Job = patient.Job,
                CreatedDate = patient.CreatedDate
            });
        }
    }
}
