using IMS.CoreBusiness.Entities;
using IMS.UseCases.Interfaces.WriteOffInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.WriteOffUseCases
{
    public class AddWriteOffUseCase : IAddWriteOffUseCase
    {
        private readonly IWriteOffRepository writeOffRepository;

        public AddWriteOffUseCase(IWriteOffRepository writeOffRepository)
        {
            this.writeOffRepository = writeOffRepository;
        }

        public async Task ExecuteAsync(MaterialWriteOff writeOff, int currentMasterId)
        {
            if (string.IsNullOrWhiteSpace(writeOff.Reason))
            {
                throw new ArgumentException("Причина списания не может быть пустой", nameof(writeOff.Reason));
            }

            if (writeOff.Items is null || !writeOff.Items.Any())
            {
                throw new ArgumentException("Списание должно содержать хотябы один материал", nameof(writeOff.Items));
            }

            await this.writeOffRepository.AddWriteOffAsync(writeOff, currentMasterId);
        }
    }
}
