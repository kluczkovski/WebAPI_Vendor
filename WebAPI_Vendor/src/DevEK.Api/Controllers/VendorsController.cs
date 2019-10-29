using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DevEK.Api.ViewModels;
using DevEK.Business.Interfaces;
using DevEK.Business.Models;
using DevEK.Business.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevEK.Api.Controllers
{
    [Route("api/[controller]")]
    public class VendorsController : MainController
    {
        private readonly IVendorRepository _vendorRespository;
        private readonly IAddressRepository _addressRespository;
        private readonly IMapper _mapper;
        private readonly IVendorService _vendorService;

        public VendorsController(IVendorRepository vendorRepository,
                                 IAddressRepository addressRepository,
                                 IMapper mapper,
                                 IVendorService vendorService,
                                 INotify notify) : base(notify)
        {
            _vendorRespository = vendorRepository;
            _addressRespository = addressRepository;
            _mapper = mapper;
            _vendorService = vendorService;
        }


        //This is way return ActionResult and 200 code
        //public async Task<ActionResult<IEnumerable<VendorDTO>>> GetAllVendos()
        //{
        //    var vendors = _mapper.Map<IEnumerable<VendorDTO>>(await _vendorRespository.GetList());
        //    return Ok(vendors);
        //}

        //This way return only IEnumrable, wihtout 200 code
        [HttpGet]
        public async Task<IEnumerable<VendorDTO>> GetAllVendos()
        {
            var vendors = _mapper.Map<IEnumerable<VendorDTO>>(await _vendorRespository.GetList());
            return vendors;
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<VendorDTO>> GetVendorByID(Guid id)
        {
            var vendor = _mapper.Map<VendorDTO>(await _vendorRespository.GetVendorProducsAddress(id));
            if (vendor == null)
            {
                return NotFound();
            }

            return vendor;
        }


        [HttpGet("get-address/{id:guid}")]
        public async Task<ActionResult<AddressDTO>> GetAddress(Guid id)
        {
            var addressDTO = _mapper.Map<AddressDTO>(await _addressRespository.GetById(id));
            if (addressDTO == null)
            {
                return NotFound();
            }
            return addressDTO;
        }


        [HttpPost]
        public async Task<ActionResult<VendorDTO>> Add(VendorDTO vendorDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var vendor = _mapper.Map<Vendor>(vendorDTO);
            await _vendorService.Add(vendor);

           return CustomResponse(vendorDTO);
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult<VendorDTO>> Update(Guid id, [FromBody]VendorDTO vendorDTO)
        {
            if (id != vendorDTO.Id)
            {
                NotifyError("Id from Query is different from the body.");
                return CustomResponse(vendorDTO);
            }
            
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var vendor = _mapper.Map<Vendor>(vendorDTO);
            await _vendorService.Update(vendor);

            return CustomResponse(vendorDTO);
        }

        [HttpPut("put-address/{id:guid}")]
        public async Task<ActionResult<AddressDTO>> UpdateAddress(Guid id, [FromBody]AddressDTO addressDTO)
        {
            if (id != addressDTO.Id)
            {
                NotifyError("Id from Query is different from the body.");
                return CustomResponse(addressDTO);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var address = _mapper.Map<Address>(addressDTO);
            await _vendorService.UpdateAddress(address);

            return CustomResponse(addressDTO);
        }


        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<VendorDTO>> Delete(Guid id)
        {
            var vendor = await _vendorRespository.GetById(id);
            if (vendor == null) return NotFound();

            var result = await _vendorService.Remove(id);
           
            return CustomResponse();
        }
    }
}
