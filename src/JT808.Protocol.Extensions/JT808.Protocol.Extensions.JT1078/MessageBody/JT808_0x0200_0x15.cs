﻿using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessageBody;
using JT808.Protocol.MessagePack;
using System;
using System.Text.Json;

namespace JT808.Protocol.Extensions.JT1078.MessageBody
{
    /// <summary>
    /// 视频信号丢失报警状态
    /// 0x0200_0x15
    /// </summary>
    public class JT808_0x0200_0x15 : JT808_0x0200_BodyBase, IJT808MessagePackFormatter<JT808_0x0200_0x15>, IJT808Analyze
    {
        /// <summary>
        /// 
        /// </summary>
        public override byte AttachInfoId { get; set; } = 0x15;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte AttachInfoLength { get; set; } = 4;
        /// <summary>
        /// 视频信号丢失报警状态
        /// </summary>
        public uint VideoSignalLoseAlarmStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x0200_0x15 value = new JT808_0x0200_0x15();
            value.AttachInfoId = reader.ReadByte();
            writer.WriteNumber($"[{value.AttachInfoId.ReadNumber()}]附加信息Id", value.AttachInfoId);
            value.AttachInfoLength = reader.ReadByte();
            writer.WriteNumber($"[{value.AttachInfoLength.ReadNumber()}]附加信息长度", value.AttachInfoLength);
            value.VideoSignalLoseAlarmStatus = reader.ReadUInt32();
            writer.WriteNumber($"[{value.VideoSignalLoseAlarmStatus.ReadNumber()}]视频信号丢失报警状态", value.VideoSignalLoseAlarmStatus);
            var videoSignalLoseAlarmStatusSpan = Convert.ToString(value.VideoSignalLoseAlarmStatus, 2).PadLeft(32, '0').AsSpan();
            writer.WriteStartArray("视频信号丢失报警状态集合");
            int index = 0;
            foreach (var item in videoSignalLoseAlarmStatusSpan)
            {
                if (item == '1')
                {
                    writer.WriteStringValue($"{index}通道视频信号丢失");
                }
                else
                {
                    writer.WriteStringValue($"{index}通道视频正常");
                }
                index++;
            }
            writer.WriteEndArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public JT808_0x0200_0x15 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x0200_0x15 value = new JT808_0x0200_0x15();
            value.AttachInfoId = reader.ReadByte();
            value.AttachInfoLength = reader.ReadByte();
            value.VideoSignalLoseAlarmStatus = reader.ReadUInt32();
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x0200_0x15 value, IJT808Config config)
        {
            writer.WriteByte(value.AttachInfoId);
            writer.WriteByte(value.AttachInfoLength);
            writer.WriteUInt32(value.VideoSignalLoseAlarmStatus);
        }
    }
}
