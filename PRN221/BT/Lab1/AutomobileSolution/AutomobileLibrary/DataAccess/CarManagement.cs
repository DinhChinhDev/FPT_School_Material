using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary.DataAccess;

namespace AutomobileLibrary.DataAccess
{
    public class CarManagement
    {
        private static CarManagement instance = null;
        private static readonly object instanceLock = new object();
        private CarManagement() { }
        public static CarManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Car> GetCarList()
        {
            List<Car> cars;
            try
            {
                var myStockDB = new MyStockContext();
                cars = myStockDB.Cars.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cars;
        }
        //-------------------------------
        public Car GetCarByID(int carID)
        {
            Car car = null;
            try
            {
                var myStockDB = new MyStockContext();
                car = myStockDB.Cars.SingleOrDefault(car => car.CarId == carID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return car;
        }
        //------------------------------
        public void AddNew(Car car)
        {
            try
            {
                Car _car = GetCarByID(car.CarId);
                if (_car == null)
                {
                    var myStockDB = new MyStockContext();
                    myStockDB.Cars.Add(car);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The car is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public void AddNew(Car car)
        //{
        //    try
        //    {
        //        using (var myStockDB = new MyStockContext())
        //        {
        //            // Kiểm tra nếu CarId đã được chỉ định và tồn tại
        //            if (car.CarId != 0 && myStockDB.Cars.Any(c => c.CarId == car.CarId))
        //            {
        //                throw new Exception("The car with the specified ID already exists.");
        //            }

        //            // Thêm bản ghi mới mà không cần chỉ định CarId
        //            if (car.CarId == 0)
        //            {
        //                // CarId sẽ được tự động tạo bởi cơ sở dữ liệu nếu là trường IDENTITY
        //                myStockDB.Cars.Add(car);
        //            }
        //            else
        //            {
        //                // Cập nhật bản ghi nếu ID đã được chỉ định và tồn tại trong cơ sở dữ liệu
        //                var existingCar = myStockDB.Cars.Find(car.CarId);
        //                if (existingCar != null)
        //                {
        //                    myStockDB.Entry(existingCar).CurrentValues.SetValues(car);
        //                }
        //                else
        //                {
        //                    throw new Exception("The car does not exist.");
        //                }
        //            }

        //            int affectedRows = myStockDB.SaveChanges();
        //            if (affectedRows == 0)
        //            {
        //                throw new Exception("No rows were affected by the operation.");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}


        //------------------------------
        public void Update(Car car)
        {
            try
            {
                Car c = GetCarByID(car.CarId);
                if (c != null)
                {
                    var myStockDB = new MyStockContext();
                    myStockDB.Entry(car).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The car does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //------------------------------
        public void Remove(Car car)
        {
            try
            {
                Car _car = GetCarByID(car.CarId);
                if (_car != null)
                {
                    var myStockDB = new MyStockContext();
                    myStockDB.Cars.Remove(car);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The car does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }    
}

