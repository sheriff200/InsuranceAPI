USE [InsuranceDB]
GO
/****** Object:  Table [dbo].[AuditTrail]    Script Date: 11/6/2023 11:11:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditTrail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Browser] [varchar](50) NULL,
	[IPAddress] [varchar](50) NULL,
	[UserName] [varchar](30) NULL,
	[ActivityTime] [datetime] NULL,
	[Description] [varchar](300) NULL,
 CONSTRAINT [PK_AuditTrail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthorizationToken]    Script Date: 11/6/2023 11:11:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorizationToken](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[AccessToken] [varchar](max) NULL,
	[RefreshToken] [varchar](max) NULL,
	[RefreshTokenExpiryTime] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_AuthorizationToken] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Claims]    Script Date: 11/6/2023 11:11:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Claims](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ClaimID] [bigint] NOT NULL,
	[NationalIDNumber] [bigint] NULL,
	[Expenses] [varchar](500) NULL,
	[ExpenseAmount] [decimal](18, 2) NULL,
	[ExpenseDate] [datetime] NOT NULL,
	[ClaimStatus] [varchar](20) NOT NULL,
	[LastProcessor] [varchar](50) NULL,
	[AppStage] [int] NOT NULL,
	[NextStage] [int] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Claims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PolicyHolders]    Script Date: 11/6/2023 11:11:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PolicyHolders](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NationalIDNumber] [bigint] NOT NULL,
	[Name] [varchar](80) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[DateofBirth] [date] NOT NULL,
	[PolicyNumber] [varchar](80) NOT NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_PolicyHolders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/6/2023 11:11:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](30) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[Role] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AuditTrail] ON 

INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (1, N'Edge 119.0', N'10.2.132.12', N'PolicyHolder', CAST(N'2023-11-06T10:37:42.407' AS DateTime), N'LogIn')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (2, N'Edge 119.0', N'10.2.132.12', N'PolicyHolder', CAST(N'2023-11-06T10:39:08.087' AS DateTime), N'LogIn')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (3, N'Edge 119.0', N'10.2.132.12', N'PolicyHolder', CAST(N'2023-11-06T10:43:00.230' AS DateTime), N'Get all claims')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (4, N'Edge 119.0', N'10.2.132.12', N'PolicyHolder', CAST(N'2023-11-06T11:52:01.710' AS DateTime), N'LogIn')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (5, N'Edge 119.0', N'10.2.132.12', N'PolicyHolder', CAST(N'2023-11-06T13:27:21.497' AS DateTime), N'LogIn')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (6, N'Edge 119.0', N'10.2.132.12', N'Reviewer', CAST(N'2023-11-06T13:30:29.393' AS DateTime), N'LogIn')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (7, N'Edge 119.0', N'10.2.132.12', N'Reviewer', CAST(N'2023-11-06T13:30:55.243' AS DateTime), N'Process claims')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (8, N'Edge 119.0', N'10.2.132.12', N'Reviewer', CAST(N'2023-11-06T13:31:09.143' AS DateTime), N'Process claims')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (9, N'Edge 119.0', N'10.2.132.12', N'Approval', CAST(N'2023-11-06T13:33:40.933' AS DateTime), N'LogIn')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (10, N'Edge 119.0', N'10.2.132.12', N'Approval', CAST(N'2023-11-06T13:34:54.503' AS DateTime), N'Process claims')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (11, N'Edge 119.0', N'10.2.132.12', N'Approval', CAST(N'2023-11-06T13:35:03.160' AS DateTime), N'Process claims')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (12, N'Edge 119.0', N'10.2.132.12', N'Approval', CAST(N'2023-11-06T13:45:19.447' AS DateTime), N'LogIn')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (13, N'Edge 119.0', N'10.2.132.12', N'Approval', CAST(N'2023-11-06T13:54:33.133' AS DateTime), N'LogIn')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (14, N'Edge 119.0', N'10.2.132.12', N'Approval', CAST(N'2023-11-06T13:54:55.327' AS DateTime), N'Get all claims')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (15, N'Edge 119.0', N'10.2.132.12', NULL, CAST(N'2023-11-06T21:34:03.760' AS DateTime), N'Get all claims')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (16, N'Edge 119.0', N'10.2.132.12', NULL, CAST(N'2023-11-06T22:06:56.953' AS DateTime), N'Get all claims')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (17, N'Edge 119.0', N'10.2.132.12', N'Approval', CAST(N'2023-11-06T22:07:27.967' AS DateTime), N'LogIn')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (18, N'Edge 119.0', N'10.2.132.12', N'Approval', CAST(N'2023-11-06T22:08:55.450' AS DateTime), N'Generate refresh token')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (19, N'Edge 119.0', N'10.2.132.12', NULL, CAST(N'2023-11-06T22:13:14.507' AS DateTime), N'Get all claims')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (20, N'Edge 119.0', N'10.2.132.12', NULL, CAST(N'2023-11-06T22:15:50.587' AS DateTime), N'Get all claims')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (21, N'Edge 119.0', N'10.2.132.12', N'Approval', CAST(N'2023-11-06T22:21:02.983' AS DateTime), N'LogIn')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (22, N'Edge 119.0', N'10.2.132.12', N'Approval', CAST(N'2023-11-06T22:24:53.487' AS DateTime), N'LogIn')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (23, N'Edge 119.0', N'10.2.132.12', N'Approval', CAST(N'2023-11-06T22:28:46.223' AS DateTime), N'Generate refresh token')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (24, N'Edge 119.0', N'10.2.132.12', N'PolicyHolder', CAST(N'2023-11-06T22:34:54.507' AS DateTime), N'LogIn')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (25, N'Edge 119.0', N'10.2.132.12', N'Reviewer', CAST(N'2023-11-06T22:38:46.240' AS DateTime), N'LogIn')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (26, N'Edge 119.0', N'10.2.132.12', N'Reviewer', CAST(N'2023-11-06T22:39:27.860' AS DateTime), N'Process claims')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (27, N'Edge 119.0', N'10.2.132.12', N'Reviewer', CAST(N'2023-11-06T22:39:36.917' AS DateTime), N'Process claims')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (28, N'Edge 119.0', N'10.2.132.12', N'Reviewer', CAST(N'2023-11-06T22:39:58.217' AS DateTime), N'Process claims')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (29, N'Edge 119.0', N'10.2.132.12', N'Reviewer', CAST(N'2023-11-06T22:41:40.250' AS DateTime), N'Process claims')
INSERT [dbo].[AuditTrail] ([Id], [Browser], [IPAddress], [UserName], [ActivityTime], [Description]) VALUES (30, N'Edge 119.0', N'192.168.43.165', N'Reviewer', CAST(N'2023-11-06T22:48:21.317' AS DateTime), N'Get all claims')
SET IDENTITY_INSERT [dbo].[AuditTrail] OFF
GO
SET IDENTITY_INSERT [dbo].[AuthorizationToken] ON 

INSERT [dbo].[AuthorizationToken] ([Id], [Username], [AccessToken], [RefreshToken], [RefreshTokenExpiryTime], [CreatedDate]) VALUES (1, NULL, N'xfVDlb3CN/Juxj/nQ0b7uOwxzgiSZCXbL8lK4uXIgbe8Fyyw1M13ET/1ihBu41bEqCP9ekBcb0Yeonb4IxGRdZFun3We9+yc9mSLCilCGBtbM8DzVEuolJfgZ9QbRPHGU4+X4Rau5ql0odFROEOaB7u/zUPQd95+bIh9u2AVCiv+u65B1wPuuJre/fyu2dPM2bAwx8kt4oOsMM0bd+m+pvig0elJzK7B8Gr5t4fIBBmfYe7vmBjHkQF8jB/srPsmAo5YLf4FY1p31UVSEOk+dP31l9fgtVP5pVUSWugq1VE=', N'231xV98TIr0rMjKljPaJznLIgp6aLZ2ETj/GR8cuisMYQb8pdQ5jWBG60apkrNjh', CAST(N'2023-11-06T11:37:27.997' AS DateTime), CAST(N'2023-11-06T10:37:41.777' AS DateTime))
INSERT [dbo].[AuthorizationToken] ([Id], [Username], [AccessToken], [RefreshToken], [RefreshTokenExpiryTime], [CreatedDate]) VALUES (2, N'PolicyHolder', N'xfVDlb3CN/Juxj/nQ0b7uOwxzgiSZCXbL8lK4uXIgbe8Fyyw1M13ET/1ihBu41bEqCP9ekBcb0Yeonb4IxGRdZFun3We9+yc9mSLCilCGBtbM8DzVEuolJfgZ9QbRPHGU4+X4Rau5ql0odFROEOaB5ihTkcCaQ7LEI1zAnVat5xhR0C4BahhHWeinpOnztAwrRtaiVFepYjgqfokCNNB5zvpjsTVh6iW2PtDADSDT7gwEJMCeMMkF/cUycZrSMjPMKlkd5BOKijx5F5eAq4V04ZZd+S+SxOumiwcr0qhWAc=', N'huWPaaY3U9TlH4EYA9H6C2M8PofIuD4xPnSdC3KwH/eEL1YZ3q99tewttmhdZg+1', CAST(N'2023-11-06T11:39:07.203' AS DateTime), CAST(N'2023-11-06T10:39:07.203' AS DateTime))
INSERT [dbo].[AuthorizationToken] ([Id], [Username], [AccessToken], [RefreshToken], [RefreshTokenExpiryTime], [CreatedDate]) VALUES (3, N'PolicyHolder', N'xfVDlb3CN/Juxj/nQ0b7uOwxzgiSZCXbL8lK4uXIgbe8Fyyw1M13ET/1ihBu41bEqCP9ekBcb0Yeonb4IxGRdZFun3We9+yc9mSLCilCGBtbM8DzVEuolJfgZ9QbRPHGU4+X4Rau5ql0odFROEOaB4Lkv2BpKxkRHKuNQtDquR4BUqPD2AUT9pxKFaYg7ltAclsCGUeWom4K9Jzy5dpsOCUsJWt11nIII3CEBTASPj2jZ0ox6CR6DdEHEc/Yq++HuR4UDax53ibZWjJzIKMlpsu0+XPg4YAfisBRZuMo69U=', N'dz7JEFo6gcLeTgI+ukUfnsJ4Nu7h2Bu60XCifHnbnX79CPNC6zNBF/tC3PF18sDQ', CAST(N'2023-11-06T12:52:01.037' AS DateTime), CAST(N'2023-11-06T11:52:01.037' AS DateTime))
INSERT [dbo].[AuthorizationToken] ([Id], [Username], [AccessToken], [RefreshToken], [RefreshTokenExpiryTime], [CreatedDate]) VALUES (4, N'PolicyHolder', N'xfVDlb3CN/Juxj/nQ0b7uOwxzgiSZCXbL8lK4uXIgbe8Fyyw1M13ET/1ihBu41bEqCP9ekBcb0Yeonb4IxGRdZFun3We9+yc9mSLCilCGBtbM8DzVEuolJfgZ9QbRPHGU4+X4Rau5ql0odFROEOaBx8+TTJcNeTpd9mkSIAXJ4jmuvoFwATsSmz4Bjp1guf/lqnhFn4OmgIX4+BxDFU6C6sTuW7WvnWbyya0sxFut7KJyIChwwYZDr+m+j/a2A+boPpYXKgGpzvShIuvGqZjlyduGRllKYTuoZpjOea0Gto=', N'uoATxL0Zu4NCNuTQGTzlqdrbDQltBeqHGrkVWwV++MSlWZBBvL0RIqAQSwhqIMx4', CAST(N'2023-11-06T14:27:20.867' AS DateTime), CAST(N'2023-11-06T13:27:20.867' AS DateTime))
INSERT [dbo].[AuthorizationToken] ([Id], [Username], [AccessToken], [RefreshToken], [RefreshTokenExpiryTime], [CreatedDate]) VALUES (5, N'Reviewer', N'xfVDlb3CN/Juxj/nQ0b7uOwxzgiSZCXbL8lK4uXIgbe8Fyyw1M13ET/1ihBu41bEQBk3rpd0bs0wQ9CNgaVRnsXt/ZMjPabselG4/gAOPIuTiUPcN4IdTqiZ3cGX3LODYaYQ2L/Z4thIafiMiS0j/ijYFysrc6ZZPJUut8bIrjOOvYULoniLQb9rQ3oaN2M/IY2ovf2rxC0Gwo6VvGg6XUKuM/PY+LhSShna+AT/bmSq6YEpMl2D1e+cXIlpc4o1LFkCWWSong+pZbOPPHa2VD28SNEwzDqf1QEUStqdQZY=', N'sCXMAATnlKYOtYuSosHkz8/2vZIcv/F6HncSBhBEGfwtXaPiuq6uruml9G8OnCmi', CAST(N'2023-11-06T14:30:29.377' AS DateTime), CAST(N'2023-11-06T13:30:29.377' AS DateTime))
INSERT [dbo].[AuthorizationToken] ([Id], [Username], [AccessToken], [RefreshToken], [RefreshTokenExpiryTime], [CreatedDate]) VALUES (6, N'Approval', N'xfVDlb3CN/Juxj/nQ0b7uOwxzgiSZCXbL8lK4uXIgbe8Fyyw1M13ET/1ihBu41bE4QNMC+S4tgNOz9MwtWojYSLyocuHSO4QvN3PX6l8NlL7jusEYyV2dKBXAQIRFFuJSRypmGqLhC4XdOhYFn6VD30CluF92DklNVL/gIRAqttKmuRc88mfja5aSII/qITDa81VcqZHJY2gNEuu7Z1KPoqucZiwUGNaz2dYsO70q4D1lCaPArdEIWynou0dAJv202tR3GxkfJZ0sFvU8DXpC3Z9IN864a49+b+SaB4oqYA=', N'iBrHArd7SbviLebQfBRT82H22LGwhEIbmtV4vDhXpyrG80LSkWdyrDMzW2SbJtY5', CAST(N'2023-11-06T14:33:40.917' AS DateTime), CAST(N'2023-11-06T13:33:40.917' AS DateTime))
INSERT [dbo].[AuthorizationToken] ([Id], [Username], [AccessToken], [RefreshToken], [RefreshTokenExpiryTime], [CreatedDate]) VALUES (7, N'Approval', N'xfVDlb3CN/Juxj/nQ0b7uOwxzgiSZCXbL8lK4uXIgbe8Fyyw1M13ET/1ihBu41bE4QNMC+S4tgNOz9MwtWojYSLyocuHSO4QvN3PX6l8NlL7jusEYyV2dKBXAQIRFFuJSRypmGqLhC4XdOhYFn6VDzQm5szvyuY+Gtr7YB97/12l+oh2P3GBNmiAndHtVBghk1MXE5WhO8IE+7Wgu1AjcO6z6xS5JqDko+eEBpdG0rbfHEBk/fq9aZrO9gEzDMY9T6fFYwihkpd/SCcutWopwE7KbExAH+eCBf1HHpE7R2w=', N'Nwm6F/cL7hBt9SyOt6PVKFpVLa1oU+3bpVziTrOpMD4xPThUeeh1xmuehoPpwufA', CAST(N'2023-11-06T14:45:18.750' AS DateTime), CAST(N'2023-11-06T13:45:18.750' AS DateTime))
INSERT [dbo].[AuthorizationToken] ([Id], [Username], [AccessToken], [RefreshToken], [RefreshTokenExpiryTime], [CreatedDate]) VALUES (8, N'Approval', N'xfVDlb3CN/Juxj/nQ0b7uOwxzgiSZCXbL8lK4uXIgbe8Fyyw1M13ET/1ihBu41bE4QNMC+S4tgNOz9MwtWojYSLyocuHSO4QvN3PX6l8NlL7jusEYyV2dKBXAQIRFFuJSRypmGqLhC4XdOhYFn6VD3o/0jIrVws+cmDKkQBCOp4LkG1Qh81MK6eMpqL31SGWeaUsdr6VQxZC0QloEWSldiYiNnewkkhDQ63WZdffXIOoubq/lZhID7tt+zblJB6EdleRNN1IoM/n9B47Ul76G1GDzNzBIubHHBrvnMoiuJ0=', N'pbvCGSSb4Amg2W//rE4H/e08AxMfWwT3b4975/j04+dU8KdLU7onVDjDmQ+/1d38', CAST(N'2023-11-06T14:54:32.287' AS DateTime), CAST(N'2023-11-06T13:54:32.287' AS DateTime))
INSERT [dbo].[AuthorizationToken] ([Id], [Username], [AccessToken], [RefreshToken], [RefreshTokenExpiryTime], [CreatedDate]) VALUES (9, N'Approval', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBcHByb3ZhbCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJBcHByb3ZhbCIsIm5iZiI6MTY5OTMwNDg0NywiZXhwIjoxNjk5MzA4NTM1LCJpYXQiOjE2OTkzMDQ4NDd9.xUVBjTSQACtA8BcQlxm0bLkuEcp3BHSClofzt_zMqUE', N'5yXDT9iMWECxxMESQ39MzzSbPL4nxqnQqxJtIQumACE=', CAST(N'2023-11-06T23:07:27.700' AS DateTime), CAST(N'2023-11-06T22:07:27.700' AS DateTime))
INSERT [dbo].[AuthorizationToken] ([Id], [Username], [AccessToken], [RefreshToken], [RefreshTokenExpiryTime], [CreatedDate]) VALUES (10, N'Approval', N'xfVDlb3CN/Juxj/nQ0b7uOwxzgiSZCXbL8lK4uXIgbe8Fyyw1M13ET/1ihBu41bE4QNMC+S4tgNOz9MwtWojYSLyocuHSO4QvN3PX6l8NlL7jusEYyV2dKBXAQIRFFuJ9yTHKVta0+fdxL9lBN9jlKV3MyvT8X30aSmX73L+rjD5qxwkifm/4utyj+WDsF7UF+VgLiZS2GITJSGBapcuBwjj9U3w9Jwn5ROb8ULxeWQKuXwMUHTug+6rYEeL0luR3X4b9wIByl2F+wl01JDhITvDHuJotDE0mUixEdZuZHI=', N'Bnn/u/9GGh+TT+sivg61nZsfwPgeSxPdamLDJLuZAtB9gwe+d3mEwjrs7UKP5Y7J', CAST(N'2023-11-06T23:21:02.310' AS DateTime), CAST(N'2023-11-06T22:21:02.310' AS DateTime))
INSERT [dbo].[AuthorizationToken] ([Id], [Username], [AccessToken], [RefreshToken], [RefreshTokenExpiryTime], [CreatedDate]) VALUES (11, N'Approval', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBcHByb3ZhbCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJBcHByb3ZhbCIsIm5iZiI6MTY5OTMwNTg5MiwiZXhwIjoxNjk5MzA5NzI1LCJpYXQiOjE2OTkzMDU4OTJ9.5_Otly_tBny3hR7SUCSOM4zEgOFrjWbusGBgwjfGRyw', N'vqqcTj/h21LlPpun458crAIJ2EN2eF9YHghixOs06fs=', CAST(N'2023-11-06T23:24:52.847' AS DateTime), CAST(N'2023-11-06T22:24:52.847' AS DateTime))
INSERT [dbo].[AuthorizationToken] ([Id], [Username], [AccessToken], [RefreshToken], [RefreshTokenExpiryTime], [CreatedDate]) VALUES (12, N'PolicyHolder', N'xfVDlb3CN/Juxj/nQ0b7uOwxzgiSZCXbL8lK4uXIgbe8Fyyw1M13ET/1ihBu41bEqCP9ekBcb0Yeonb4IxGRdZFun3We9+yc9mSLCilCGBtbM8DzVEuolJfgZ9QbRPHGU4+X4Rau5ql0odFROEOaBxqA7dPwtG0Kfv0gfNz7ITRp1KkjobJF9G0FvS13Rr0rB4CV7njeTwdNedTs5wGlkg+ABXrM0oF2SCJ1qfKaVQqmm6DDFWZwlrKDjviBDqk3ThnNck8lZL/ooHCJhOEiRO6/toSNdsvrcofo9EcsHsw=', N'Sz8vPzn83nHg2he778ZgpNOe+yLmZ3dM9V68zfkG0c8N5zBaNGvSTbQ8iEL4kZKI', CAST(N'2023-11-06T23:34:53.993' AS DateTime), CAST(N'2023-11-06T22:34:53.993' AS DateTime))
INSERT [dbo].[AuthorizationToken] ([Id], [Username], [AccessToken], [RefreshToken], [RefreshTokenExpiryTime], [CreatedDate]) VALUES (13, N'Reviewer', N'xfVDlb3CN/Juxj/nQ0b7uOwxzgiSZCXbL8lK4uXIgbe8Fyyw1M13ET/1ihBu41bEQBk3rpd0bs0wQ9CNgaVRnsXt/ZMjPabselG4/gAOPIuTiUPcN4IdTqiZ3cGX3LODlBBwcn3557myOM/349u55cLT20kbTOgorld3bGMVT2+gOm+0ejMZ79vXTxzyy7Y2WYUnjhGLFQ1c+AqIzUbUWIQNGlELUNQqUIZUtriOifNS8xVPX0TPWyewjXbnhkiUGDXF7i0nsb000QKhkbDUHIBqXk5ybhbggoSczw1bZfM=', N'LmjngoDNaTP1zTEaHpc8ts4IJIuNy36o9vAk+3K2OVLys9Ajwe7ZsCpKqI3yaeOY', CAST(N'2023-11-06T23:38:46.220' AS DateTime), CAST(N'2023-11-06T22:38:46.220' AS DateTime))
SET IDENTITY_INSERT [dbo].[AuthorizationToken] OFF
GO
SET IDENTITY_INSERT [dbo].[Claims] ON 

INSERT [dbo].[Claims] ([Id], [ClaimID], [NationalIDNumber], [Expenses], [ExpenseAmount], [ExpenseDate], [ClaimStatus], [LastProcessor], [AppStage], [NextStage], [CreatedDate]) VALUES (1, 1, 1, N'Transportation', CAST(2000.00 AS Decimal(18, 2)), CAST(N'2023-11-06T00:00:00.000' AS DateTime), N'Approved', N'Approval', 2, 4, CAST(N'2023-11-06T11:08:03.553' AS DateTime))
INSERT [dbo].[Claims] ([Id], [ClaimID], [NationalIDNumber], [Expenses], [ExpenseAmount], [ExpenseDate], [ClaimStatus], [LastProcessor], [AppStage], [NextStage], [CreatedDate]) VALUES (2, 2, 2, N'Transportation', CAST(2100.00 AS Decimal(18, 2)), CAST(N'2023-11-06T00:00:00.000' AS DateTime), N'In-Review', N'Reviewer', 1, 2, CAST(N'2023-11-06T11:10:46.763' AS DateTime))
INSERT [dbo].[Claims] ([Id], [ClaimID], [NationalIDNumber], [Expenses], [ExpenseAmount], [ExpenseDate], [ClaimStatus], [LastProcessor], [AppStage], [NextStage], [CreatedDate]) VALUES (3, 3, 3, N'Transportation', CAST(2200.00 AS Decimal(18, 2)), CAST(N'2023-11-06T00:00:00.000' AS DateTime), N'In-Review', N'Reviewer', 1, 2, CAST(N'2023-11-06T11:11:39.953' AS DateTime))
INSERT [dbo].[Claims] ([Id], [ClaimID], [NationalIDNumber], [Expenses], [ExpenseAmount], [ExpenseDate], [ClaimStatus], [LastProcessor], [AppStage], [NextStage], [CreatedDate]) VALUES (4, 4, 4, N'Transportation', CAST(2300.00 AS Decimal(18, 2)), CAST(N'2023-11-06T00:00:00.000' AS DateTime), N'Submitted', N'PolicyHolder', 0, 1, CAST(N'2023-11-06T11:12:58.027' AS DateTime))
INSERT [dbo].[Claims] ([Id], [ClaimID], [NationalIDNumber], [Expenses], [ExpenseAmount], [ExpenseDate], [ClaimStatus], [LastProcessor], [AppStage], [NextStage], [CreatedDate]) VALUES (5, 5, 5, N'Transportation', CAST(2400.00 AS Decimal(18, 2)), CAST(N'2023-11-06T00:00:00.000' AS DateTime), N'Submitted', N'PolicyHolder', 0, 1, CAST(N'2023-11-06T11:15:27.323' AS DateTime))
INSERT [dbo].[Claims] ([Id], [ClaimID], [NationalIDNumber], [Expenses], [ExpenseAmount], [ExpenseDate], [ClaimStatus], [LastProcessor], [AppStage], [NextStage], [CreatedDate]) VALUES (6, 6, 6, N'Feeding', CAST(3000.00 AS Decimal(18, 2)), CAST(N'2023-09-09T00:00:00.000' AS DateTime), N'Submitted', N'PolicyHolder', 0, 1, CAST(N'2023-11-06T13:28:59.007' AS DateTime))
INSERT [dbo].[Claims] ([Id], [ClaimID], [NationalIDNumber], [Expenses], [ExpenseAmount], [ExpenseDate], [ClaimStatus], [LastProcessor], [AppStage], [NextStage], [CreatedDate]) VALUES (7, 7, 1, N'Wedding', CAST(12000.00 AS Decimal(18, 2)), CAST(N'2023-04-07T00:00:00.000' AS DateTime), N'Submitted', N'PolicyHolder', 0, 1, CAST(N'2023-11-06T22:36:30.560' AS DateTime))
SET IDENTITY_INSERT [dbo].[Claims] OFF
GO
SET IDENTITY_INSERT [dbo].[PolicyHolders] ON 

INSERT [dbo].[PolicyHolders] ([Id], [NationalIDNumber], [Name], [Surname], [DateofBirth], [PolicyNumber], [CreatedDate]) VALUES (1, 1, N'Sheriff', N'Ebelebe', CAST(N'1960-11-06' AS Date), N'1', CAST(N'2023-11-06T11:07:42.613' AS DateTime))
INSERT [dbo].[PolicyHolders] ([Id], [NationalIDNumber], [Name], [Surname], [DateofBirth], [PolicyNumber], [CreatedDate]) VALUES (2, 2, N'Moses', N'Joy', CAST(N'1961-11-06' AS Date), N'2', CAST(N'2023-11-06T11:10:46.747' AS DateTime))
INSERT [dbo].[PolicyHolders] ([Id], [NationalIDNumber], [Name], [Surname], [DateofBirth], [PolicyNumber], [CreatedDate]) VALUES (3, 3, N'Paul', N'Ola', CAST(N'1962-11-06' AS Date), N'3', CAST(N'2023-11-06T11:11:39.947' AS DateTime))
INSERT [dbo].[PolicyHolders] ([Id], [NationalIDNumber], [Name], [Surname], [DateofBirth], [PolicyNumber], [CreatedDate]) VALUES (4, 4, N'Odia', N'Okafor', CAST(N'1963-11-06' AS Date), N'4', CAST(N'2023-11-06T11:12:58.023' AS DateTime))
INSERT [dbo].[PolicyHolders] ([Id], [NationalIDNumber], [Name], [Surname], [DateofBirth], [PolicyNumber], [CreatedDate]) VALUES (5, 5, N'Uche', N'James', CAST(N'1964-11-06' AS Date), N'5', CAST(N'2023-11-06T11:15:27.317' AS DateTime))
INSERT [dbo].[PolicyHolders] ([Id], [NationalIDNumber], [Name], [Surname], [DateofBirth], [PolicyNumber], [CreatedDate]) VALUES (6, 6, N'Chuks', N'Oma', CAST(N'1980-09-09' AS Date), N'6', CAST(N'2023-11-06T13:28:58.993' AS DateTime))
INSERT [dbo].[PolicyHolders] ([Id], [NationalIDNumber], [Name], [Surname], [DateofBirth], [PolicyNumber], [CreatedDate]) VALUES (7, 1, N'Lucy', N'Frank', CAST(N'1987-09-09' AS Date), N'7', CAST(N'2023-11-06T22:36:30.543' AS DateTime))
SET IDENTITY_INSERT [dbo].[PolicyHolders] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [Role], [CreatedDate]) VALUES (1, N'Reviewer', N'JQrjuR3AY7oDrpvcvhGdWg==', N'Reviewer', CAST(N'2023-11-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role], [CreatedDate]) VALUES (2, N'Approval', N'JQrjuR3AY7oDrpvcvhGdWg==', N'Approval', CAST(N'2023-11-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role], [CreatedDate]) VALUES (3, N'PolicyHolder', N'JQrjuR3AY7oDrpvcvhGdWg==', N'PolicyHolder', CAST(N'2023-11-06T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAuthorizedUserByUsername]    Script Date: 11/6/2023 11:11:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAuthorizedUserByUsername]
	@UserName varchar(80)
AS
BEGIN
	
	SET NOCOUNT ON;
   select * from AuthorizationToken where Username =@UserName order by Id desc
END
GO
