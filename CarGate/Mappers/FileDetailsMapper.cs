using CarGate.Models.Cepik;
using CarLibrary.Models.DTO.FilesDetails;

namespace CarGate.Mappers;

public static class FileDetailsMapper
{
    public static FileDetailsDTO Map(CepikFileDetailsData src)
    {
        if (src == null)
            return null;

        return new FileDetailsDTO
        {
            Id = src.id,
            Attributes = MapAttributes(src.attributes)
        };
    }

    private static FileAttributesDTO MapAttributes(CepikFileDetailsAttributes src)
    {
        if (src == null)
            return null;

        return new FileAttributesDTO
        {
            FileUrl = src.FileUrl,
            MetadataUrl = src.MetadataUrl,
            ContentDescription = src.ContentDescription,
            FileFormatDescription = src.FileFormat,
            ResourceType = src.ResourceType,
            FileCreationDate = src.CreationDate
        };
    }
}
