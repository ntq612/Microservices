using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services;

public class DiscountService 
    (DiscountContext dbContext, ILogger<DiscountService> logger)
    : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext
            .Coupons
            .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
        if (coupon == null)
        {
            coupon = new Models.Coupon
            {
                ProductName = "No Discount",
                Amount = 0,
                Description = "No coupon found"
            };
        }
        logger.LogInformation("Discount is retrieved for ProductName: {productName}, Amount: {amount}", coupon.ProductName, coupon.Amount);
        var couponModel = coupon.Adapt<CouponModel>();
        couponModel.Desciption = coupon.Description;
        return couponModel;
    }
    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();
        coupon.Description = request.Coupon.Desciption;
        if(coupon == null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request"));
        }
        dbContext.Coupons.Add(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Discount is successfully created. Productname is {productName} ", coupon.ProductName);
        return request.Coupon;
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupons = request.Coupon.Adapt<Coupon>();
        coupons.Description = request.Coupon.Desciption;
        if(coupons == null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request"));
        }
        dbContext.Coupons.Update(coupons);
        await dbContext.SaveChangesAsync();
        return coupons.Adapt<CouponModel>();
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext
            .Coupons
            .FirstOrDefaultAsync(x => x.Id == request.Coupon.Id);
        if(coupon == null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request"));
        }
        dbContext.Coupons.Remove(coupon);
        await dbContext.SaveChangesAsync();
        return new DeleteDiscountResponse { Success = true };
    }
}
