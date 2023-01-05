using ChallengeGYF.API.Controllers;
using Microsoft.Extensions.Logging;
using DTOEntity = ChallengeGYF.Shared.DTO.DTOProducto;
using ChallengeGYF.DAL.EF.Models;
using ChallengeGYF.DAL.Interfaces;



namespace ChallengeGYF.Test;

public class ProductoTest
{

    private readonly IProducto<DTOEntity> _bll;
    private readonly ILogger<ProductoController> _logger;

    public ProductoTest(ILogger<ProductoController> logger,
                                        IProducto<DTOEntity> bll)
    {
        _logger = logger;
        _bll = bll;
    }

    [Fact]
    public void Vender_Ok()
    {

        //Arrange


        //Act


        //Assert

    }
}