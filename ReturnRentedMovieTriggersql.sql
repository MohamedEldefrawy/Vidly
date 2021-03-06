USE [Vidly]
GO
/****** Object:  Trigger [dbo].[tr_ReturnRentedMovie]    Script Date: 04/03/2020 04:17:41 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Trigger [dbo].[tr_ReturnRentedMovie]
on [dbo].[Rentals]
After update
as
declare @MovieID int
begin
set @MovieID =
(
	select rd.MovieID 
	from inserted as i
	INNER JOIN RentalDetails as rd
	on i.ID = rd.RentalID
	INNER JOIN Movies as m 
	on rd.MovieID = m.ID
	where rd.MovieID = m.ID and rd.RentalID = i.ID
)

update Movies
set NumberInStock = NumberInStock + 
(
	select rd.quantity 
	from inserted as i
	INNER JOIN RentalDetails as rd
	on i.ID = rd.RentalID
	INNER JOIN Movies as m 
	on rd.MovieID = m.ID
	where rd.MovieID = m.ID and rd.RentalID = i.ID
)
where ID = @MovieID 
end	